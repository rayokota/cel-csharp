﻿/*
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
namespace Cel.Common.Types.Traits
{
	using IterableT = Cel.Common.types.IterableT;
	using Val = Cel.Common.Types.Ref.Val;

	/// <summary>
	/// Mapper interface which aggregates the traits of a maps. </summary>
	public interface Mapper : Val, Container, Indexer, IterableT, Sizer
	{

	  /// <summary>
	  /// Find returns a value, if one exists, for the input key.
	  /// 
	  /// <para>If the key is not found the function returns (nil, false). If the input key is not valid for
	  /// the map, or is Err or Unknown the function returns (Unknown|Err, false).
	  /// </para>
	  /// </summary>
	  Val Find(Val key);
	}

}