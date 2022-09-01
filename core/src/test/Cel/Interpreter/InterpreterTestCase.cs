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
namespace Cel.Interpreter
{
	/// <summary>
	/// Test case names for <seealso cref="InterpreterTest"/> and {@code InterpreterBench} JMH benchmark, latter
	/// requires this class to be a top-level public enum.
	/// </summary>
	public enum InterpreterTestCase
	{
	  and_false_1st,
	  and_false_2nd,
	  and_error_1st_false,
	  and_error_2nd_false,
	  and_error_1st_error,
	  and_error_2nd_error,
	  call_no_args,
	  call_one_arg,
	  call_two_arg,
	  call_varargs,
	  call_ns_func,
	  call_ns_func_unchecked,
	  call_ns_func_in_pkg,
	  call_ns_func_unchecked_in_pkg,
	  complex,
	  complex_qual_vars,
	  cond,
	  cond_bad_type,
	  duration_get_milliseconds,
	  elem_in_mixed_type_list,
	  elem_in_mixed_type_list_error,
	  eq_list_elem_mixed_types_error,
	  in_list,
	  in_map,
	  index,
	  index_out_of_range,
	  index_relative,
	  literal_bool_false,
	  literal_bool_true,
	  literal_empty,
	  literal_null,
	  literal_list,
	  literal_map,
	  literal_equiv_string_bytes,
	  literal_not_equiv_string_bytes,
	  literal_equiv_bytes_string,
	  literal_bytes_string,
	  literal_bytes_string2,
	  literal_pb3_msg,
	  literal_pb_enum,
	  literal_pb_struct,
	  literal_var,
	  literal_any,
	  timestamp_eq_timestamp,
	  timestamp_ne_timestamp,
	  timestamp_lt_timestamp,
	  timestamp_le_timestamp,
	  timestamp_gt_timestamp,
	  timestamp_ge_timestamp,
	  timestamp_get_hours_tz,
	  string_to_timestamp,
	  macro_all_non_strict,
	  macro_all_non_strict_var,
	  macro_exists_lit,
	  macro_exists_nonstrict,
	  macro_exists_var,
	  macro_exists_one,
	  macro_filter,
	  macro_has_map_key,
	  macro_has_pb2_field,
	  macro_has_pb3_field,
	  macro_map,
	  matches,
	  nested_proto_field,
	  nested_proto_field_with_index,
	  or_true_1st,
	  or_true_2nd,
	  or_false,
	  or_error_1st_error,
	  or_error_2nd_error,
	  or_error_1st_true,
	  or_error_2nd_true,
	  parse_nest_list_index,
	  parse_nest_message_literal,
	  parse_repeat_index,
	  pkg_qualified_id,
	  pkg_qualified_id_unchecked,
	  pkg_qualified_index_unchecked,
	  select_key,
	  select_bool_key,
	  select_uint_key,
	  select_index,
	  select_field,
	  select_literal_uint,
	  select_on_int64,
	  select_pb2_primitive_fields,
	  select_pb3_wrapper_fields,
	  select_pb3_empty_list,
	  select_pb3_enum_big,
	  select_pb3_enum_neg,
	  select_pb3_compare,
	  select_pb3_compare_signed,
	  select_pb3_unset,
	  select_custom_pb3_compare,
	  select_relative,
	  select_subsumed_field,
	  select_empty_repeated_nested
	}

}