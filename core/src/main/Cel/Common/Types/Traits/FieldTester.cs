﻿/*
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

namespace Cel.Common.Types.Traits
{
    using Val = global::Cel.Common.Types.Ref.Val;

    /// <summary>
    /// FieldTester indicates if a defined field on an object type is set to a non-default value.
    /// 
    /// <para>For use with the `has()` macro.
    /// </para>
    /// </summary>
    public interface FieldTester
    {
        /// <summary>
        /// IsSet returns true if the field is defined and set to a non-default value. The method will
        /// return false if defined and not set, and an error if the field is not defined.
        /// </summary>
        Val IsSet(Val field);
    }
}