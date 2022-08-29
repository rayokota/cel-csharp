﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

/*
 * Copyright (C) 2021 The Authors of CEL-Java
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
namespace Cel.Common.Types.Pb
{
    using Descriptor = Google.Protobuf.Reflection.MessageDescriptor;
    using EnumDescriptor = Google.Protobuf.Reflection.EnumDescriptor;
    using EnumValueDescriptor = Google.Protobuf.Reflection.EnumValueDescriptor;
    using FileDescriptor = Google.Protobuf.Reflection.FileDescriptor;

    /// <summary>
    /// FileDescription holds a map of all types and enum values declared within a proto file. </summary>
    public sealed class FileDescription
    {
        private readonly IDictionary<string, PbTypeDescription> types;
        private readonly IDictionary<string, EnumValueDescription> enums;

        private FileDescription(IDictionary<string, PbTypeDescription> types,
            IDictionary<string, EnumValueDescription> enums)
        {
            this.types = types;
            this.enums = enums;
        }

        public override bool Equals(object o)
        {
            if (this == o)
            {
                return true;
            }

            if (o == null || this.GetType() != o.GetType())
            {
                return false;
            }

            FileDescription that = (FileDescription)o;
            return Object.Equals(types, that.types) && Object.Equals(enums, that.enums);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(types, enums);
        }

        /// <summary>
        /// NewFileDescription returns a FileDescription instance with a complete listing of all the
        /// message types and enum values declared within any scope in the file.
        /// </summary>
        public static FileDescription NewFileDescription(FileDescriptor fileDesc)
        {
            FileMetadata metadata = FileMetadata.CollectFileMetadata(fileDesc);
            IDictionary<string, EnumValueDescription> enums = new Dictionary<string, EnumValueDescription>();
            foreach (var entry in metadata.enumValues)
            {
                enums.Add(entry.Key, EnumValueDescription.NewEnumValueDescription(entry.Key, entry.Value));
            }

            IDictionary<string, PbTypeDescription> types = new Dictionary<string, PbTypeDescription>();
            foreach (var entry in metadata.msgTypes)
            {
                types.Add(entry.Key, PbTypeDescription.NewTypeDescription(entry.Key, entry.Value));
            }

            return new FileDescription(types, enums);
        }

        /// <summary>
        /// GetEnumDescription returns an EnumDescription for a qualified enum value name declared within
        /// the .proto file.
        /// </summary>
        public EnumValueDescription GetEnumDescription(string enumName)
        {
            return enums[SanitizeProtoName(enumName)];
        }

        /// <summary>
        /// GetEnumNames returns the string names of all enum values in the file. </summary>
        public string[] EnumNames
        {
            get { return enums.Keys.ToArray(); }
        }

        /// <summary>
        /// GetTypeDescription returns a TypeDescription for a qualified protobuf message type name
        /// declared within the .proto file.
        /// </summary>
        public PbTypeDescription GetTypeDescription(string typeName)
        {
            return types[SanitizeProtoName(typeName)];
        }

        /// <summary>
        /// GetTypeNames returns the list of all type names contained within the file. </summary>
        public string[] TypeNames
        {
            get { return types.Keys.ToArray(); }
        }

        /// <summary>
        /// sanitizeProtoName strips the leading '.' from the proto message name. </summary>
        internal static string SanitizeProtoName(string name)
        {
            if (!string.ReferenceEquals(name, null) && name.Length > 0 && name[0] == '.')
            {
                return name.Substring(1);
            }

            return name;
        }

        /// <summary>
        /// fileMetadata is a flattened view of message types and enum values within a file descriptor. </summary>
        internal sealed class FileMetadata
        {
            /// <summary>
            /// msgTypes maps from fully-qualified message name to descriptor. </summary>
            internal readonly IDictionary<string, Descriptor> msgTypes;

            /// <summary>
            /// enumValues maps from fully-qualified enum value to enum value descriptor. </summary>
            internal readonly IDictionary<string, EnumValueDescriptor> enumValues;
            // TODO: support enum type definitions for use in future type-check enhancements.

            internal FileMetadata(IDictionary<string, Descriptor> msgTypes,
                IDictionary<string, EnumValueDescriptor> enumValues)
            {
                this.msgTypes = msgTypes;
                this.enumValues = enumValues;
            }

            /// <summary>
            /// collectFileMetadata traverses the proto file object graph to collect message types and enum
            /// values and index them by their fully qualified names.
            /// </summary>
            internal static FileMetadata CollectFileMetadata(FileDescriptor fileDesc)
            {
                IDictionary<string, Descriptor> msgTypes = new Dictionary<string, Descriptor>();
                IDictionary<string, EnumValueDescriptor> enumValues = new Dictionary<string, EnumValueDescriptor>();

                CollectMsgTypes(fileDesc.MessageTypes, msgTypes, enumValues);
                CollectEnumValues(fileDesc.EnumTypes, enumValues);
                return new FileMetadata(msgTypes, enumValues);
            }

            /// <summary>
            /// collectMsgTypes recursively collects messages, nested messages, and nested enums into a map
            /// of fully qualified protobuf names to descriptors.
            /// </summary>
            internal static void CollectMsgTypes(IList<Descriptor> msgTypes, IDictionary<string, Descriptor> msgTypeMap,
                IDictionary<string, EnumValueDescriptor> enumValueMap)
            {
                foreach (Descriptor msgType in msgTypes)
                {
                    msgTypeMap[msgType.FullName] = msgType;
                    IList<Descriptor> nestedMsgTypes = msgType.NestedTypes;
                    if (nestedMsgTypes.Count > 0)
                    {
                        CollectMsgTypes(nestedMsgTypes, msgTypeMap, enumValueMap);
                    }

                    IList<EnumDescriptor> nestedEnumTypes = msgType.EnumTypes;
                    if (nestedEnumTypes.Count > 0)
                    {
                        CollectEnumValues(nestedEnumTypes, enumValueMap);
                    }
                }
            }

            /// <summary>
            /// collectEnumValues accumulates the enum values within an enum declaration. </summary>
            internal static void CollectEnumValues(IList<EnumDescriptor> enumTypes,
                IDictionary<string, EnumValueDescriptor> enumValueMap)
            {
                foreach (EnumDescriptor enumType in enumTypes)
                {
                    IList<EnumValueDescriptor> enumTypeValues = enumType.Values;
                    foreach (EnumValueDescriptor enumValue in enumTypeValues)
                    {
                        string enumValueName = String.Format("{0}.{1}", enumType.FullName, enumValue.Name);
                        enumValueMap[enumValueName] = enumValue;
                    }
                }
            }
        }
    }
}