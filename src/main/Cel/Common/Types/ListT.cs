﻿using System.Collections;
using Cel.Common.Operators;
using Cel.Common.Types.Ref;
using Cel.Common.Types.Traits;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Enum = System.Enum;
using Type = Cel.Common.Types.Ref.Type;

/*
 * Copyright (C) 2022 Robert Yokota
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Cel.Common.Types;

public abstract class ListT : BaseVal, Lister
{
    /// <summary>
    ///     ListType singleton.
    /// </summary>
    public static readonly Type ListType = TypeT.NewTypeValue(TypeEnum.List, Trait.AdderType, Trait.ContainerType,
        Trait.IndexerType, Trait.IterableType, Trait.SizerType);

    public abstract Val Size();
    public abstract IteratorT Iterator();
    public abstract Val Get(Val index);
    public abstract Val Contains(Val value);
    public abstract Val Add(Val other);
    public abstract override object Value();
    public abstract override Val Equal(Val other);
    public abstract override Val ConvertToType(Type typeValue);
    public abstract override object? ConvertToNative(System.Type typeDesc);

    public override Type Type()
    {
        return ListType;
    }

    public static Val NewStringArrayList(string[] value)
    {
        return NewGenericArrayList(v => StringT.StringOf((string)v), value);
    }

    public static Val NewGenericArrayList(TypeAdapter adapter, Array value)
    {
        return new GenericListT(adapter, value);
    }

    public static Val NewValArrayList(TypeAdapter adapter, Val[] value)
    {
        return new ValListT(adapter, value);
    }

    /// <summary>
    ///     NewJSONList returns a traits.Lister based on structpb.ListValue instance.
    /// </summary>
    public static Val NewJSONList(TypeAdapter adapter, ListValue l)
    {
        IList<Value> vals = l.Values;
        return NewGenericArrayList(adapter, vals.ToArray());
    }

    internal abstract class BaseListT : ListT
    {
        protected internal readonly TypeAdapter adapter;
        protected internal readonly long size;

        internal BaseListT(TypeAdapter adapter, long size)
        {
            this.adapter = adapter;
            this.size = size;
        }

        public override object? ConvertToNative(System.Type typeDesc)
        {
            if (typeDesc.IsArray)
            {
                var array = ToArray<object>(typeDesc);

                return array;
            }

            if (typeDesc == typeof(IList) || typeDesc == typeof(object)) return ToArrayList();

            if (typeDesc == typeof(ListValue)) return ToPbListValue();

            if (typeDesc == typeof(Value)) return ToPbValue();

            if (typeDesc == typeof(Any))
            {
                var v = ToPbListValue();
                //        Descriptor anyDesc = Any.getDescriptor();
                //        FieldDescriptor anyFieldTypeUrl = anyDesc.findFieldByName("type_url");
                //        FieldDescriptor anyFieldValue = anyDesc.findFieldByName("value");
                //        DynamicMessage dyn = DynamicMessage.newBuilder(Any.getDefaultInstance())
                //            .setField(anyFieldTypeUrl, )
                //            .setField(anyFieldValue, v.toByteString())
                //            .build();

                //        return (T) dyn;
                //        return (T)
                // Any.newBuilder().setTypeUrl("type.googleapis.com/google.protobuf.ListValue").setValue(dyn.toByteString()).build();
                var any = new Any();
                any.TypeUrl = "type.googleapis.com/google.protobuf.ListValue";
                any.Value = v.ToByteString();
                return any;
            }

            throw new ArgumentException(string.Format("Unsupported conversion of '{0}' to '{1}'", ListType,
                typeDesc.FullName));
        }

        internal virtual Value ToPbValue()
        {
            var value = new Value();
            value.ListValue = ToPbListValue();
            return value;
        }

        internal virtual ListValue ToPbListValue()
        {
            var list = new ListValue();
            var s = (int)size;
            for (var i = 0; i < s; i++)
            {
                var v = Get(IntT.IntOf(i));
                var e = (Value)v.ConvertToNative(typeof(Value));
                list.Values.Add(e);
            }

            return list;
        }

        internal virtual IList ToArrayList()
        {
            return new List<object> { ConvertToNative(typeof(Array)) };
        }

        internal virtual object ToArray<T>(System.Type typeDesc)
        {
            var s = (int)size;
            var compType = typeDesc.GetElementType();
            if (compType == typeof(Enum))
                // Note: cannot create `Enum` values of the right type here.
                compType = typeof(object);

            object array = Array.CreateInstance(compType, s);

            Func<object, object> fixForTarget = x => x;

            for (var i = 0; i < s; i++)
            {
                var v = Get(IntT.IntOf(i));
                var e = v.ConvertToNative(compType);
                e = fixForTarget(e);
                ((Array)array).SetValue(e, i);
            }

            return array;
        }

        public override Val ConvertToType(Type typeValue)
        {
            switch (typeValue.TypeEnum().InnerEnumValue)
            {
                case TypeEnum.InnerEnum.List:
                    return this;
                case TypeEnum.InnerEnum.Type:
                    return ListType;
            }

            return Err.NewTypeConversionError(ListType, typeValue);
        }

        public override IteratorT Iterator()
        {
            return new ArrayListIteratorT(this);
        }

        public override Val Equal(Val other)
        {
            if (other.Type() != ListType) return BoolT.False;

            var o = (ListT)other;
            if (size != o.Size().IntValue()) return BoolT.False;

            for (long i = 0; i < size; i++)
            {
                var idx = IntT.IntOf(i);
                var e1 = Get(idx);
                if (Err.IsError(e1)) return e1;

                var e2 = o.Get(idx);
                if (Err.IsError(e2)) return e2;

                if (e1.Type() != e2.Type()) return Err.NoSuchOverload(e1, Operator.Equals.id, e2);

                if (e1.Equal(e2) != BoolT.True) return BoolT.False;
            }

            return BoolT.True;
        }

        public override Val Contains(Val value)
        {
            Type firstType = null;
            Type mixedType = null;
            for (long i = 0; i < size; i++)
            {
                var elem = Get(IntT.IntOf(i));
                var elemType = elem.Type();
                if (firstType == null)
                    firstType = elemType;
                else if (!firstType.Equals(elemType)) mixedType = elemType;

                if (value.Equal(elem) == BoolT.True) return BoolT.True;
            }

            if (mixedType != null) return Err.NoSuchOverload(value, Operator.In.id, firstType, mixedType);

            return BoolT.False;
        }

        public override Val Size()
        {
            return IntT.IntOf(size);
        }

        private sealed class ArrayListIteratorT : BaseVal, IteratorT
        {
            private readonly BaseListT outerInstance;

            internal long index;

            public ArrayListIteratorT(BaseListT outerInstance)
            {
                this.outerInstance = outerInstance;
            }

            public Val HasNext()
            {
                return Types.BoolOf(index < outerInstance.size);
            }

            public Val Next()
            {
                if (index < outerInstance.size) return outerInstance.Get(IntT.IntOf(index++));

                return Err.NoMoreElements();
            }

            public override object? ConvertToNative(System.Type typeDesc)
            {
                throw new NotSupportedException("IMPLEMENT ME??");
            }

            public override Val ConvertToType(Type typeValue)
            {
                throw new NotSupportedException("IMPLEMENT ME??");
            }

            public override Val Equal(Val other)
            {
                throw new NotSupportedException("IMPLEMENT ME??");
            }

            public override Type Type()
            {
                throw new NotSupportedException("IMPLEMENT ME??");
            }

            public override object Value()
            {
                throw new NotSupportedException("IMPLEMENT ME??");
            }
        }
    }

    internal sealed class GenericListT : BaseListT
    {
        internal readonly Array array;

        internal GenericListT(TypeAdapter adapter, Array array) : base(adapter, array.Length)
        {
            this.array = array;
        }

        public override object Value()
        {
            return array;
        }

        public override Val Add(Val other)
        {
            if (!(other is Lister)) return Err.NoSuchOverload(this, "add", other);

            var otherList = (Lister)other;
            var otherArray = (Array)otherList.Value();
            var newArray = new object[array.Length + otherArray.Length];
            Array.Copy(array, 0, newArray, 0, array.Length);
            Array.Copy(otherArray, 0, newArray, array.Length, otherArray.Length);
            return new GenericListT(adapter, newArray);
        }

        public override Val Get(Val index)
        {
            if (!(index is IntT)) return Err.ValOrErr(index, "unsupported index type '{0}' in list", index.Type());

            var sz = array.Length;
            var i = (int)index.IntValue();
            if (i < 0 || i >= sz)
                // Note: the conformance tests assert on 'invalid_argument'
                return Err.NewErr("invalid_argument: index '%d' out of range in list of size '%d'", i, sz);

            return adapter(array.GetValue(i));
        }

        public override string ToString()
        {
            return "GenericListT{" + "array=" + "[" + string.Join(", ", array) + "]" + ", adapter=" + adapter +
                   ", size=" + size + '}';
        }
    }

    internal sealed class ValListT : BaseListT
    {
        internal readonly Val[] array;

        internal ValListT(TypeAdapter adapter, Val[] array) : base(adapter, array.Length)
        {
            this.array = array;
        }

        public override object Value()
        {
            var nativeArray = new object[array.Length];
            for (var i = 0; i < array.Length; i++) nativeArray[i] = array[i].Value();

            return nativeArray;
        }

        public override Val Add(Val other)
        {
            if (!(other is Lister)) return Err.NoSuchOverload(this, "add", other);

            if (other is ValListT)
            {
                var otherArray = ((ValListT)other).array;
                var newArray = new Val[array.Length + otherArray.Length];
                Array.Copy(array, 0, newArray, 0, array.Length);
                Array.Copy(otherArray, 0, newArray, array.Length, otherArray.Length);
                return new ValListT(adapter, newArray);
            }
            else
            {
                var otherLister = (Lister)other;
                var otherSIze = (int)otherLister.Size().IntValue();
                var newArray = new Val[array.Length + otherSIze];
                Array.Copy(array, 0, newArray, 0, array.Length);
                for (var i = 0; i < otherSIze; i++) newArray[array.Length + i] = otherLister.Get(IntT.IntOf(i));

                return new ValListT(adapter, newArray);
            }
        }

        public override Val Get(Val index)
        {
            if (!(index is IntT)) return Err.ValOrErr(index, "unsupported index type '{0}' in list", index.Type());

            var sz = array.Length;
            var i = (int)index.IntValue();
            if (i < 0 || i >= sz)
                // Note: the conformance tests assert on 'invalid_argument'
                return Err.NewErr("invalid_argument: index '%d' out of range in list of size '%d'", i, sz);

            return array[i];
        }

        public override bool Equals(object o)
        {
            if (this == o) return true;

            if (o == null || GetType() != o.GetType()) return false;

            var valListT = (ValListT)o;
            return array.SequenceEqual(valListT.array);
        }

        public override int GetHashCode()
        {
            var result = base.GetHashCode();
            result = 31 * result + array.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return "ValListT{" + "array=" + "[" + string.Join<Val>(", ", array) + "]" + ", adapter=" + adapter +
                   ", size=" + size + '}';
        }
    }
}