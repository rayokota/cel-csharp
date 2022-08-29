﻿using System.Text;

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
namespace Cel.Checker
{
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static Cel.Checker.Types.formatCheckedType;

    using CheckedExpr = Google.Api.Expr.V1Alpha1.CheckedExpr;
    using Expr = Google.Api.Expr.V1Alpha1.Expr;
    using Reference = Google.Api.Expr.V1Alpha1.Reference;
    using Type = Google.Api.Expr.V1Alpha1.Type;
    using Debug = global::Cel.Common.Debug.Debug;
    using Adorner = global::Cel.Common.Debug.Debug.Adorner;

    public sealed class Printer
    {
        internal sealed class SemanticAdorner : Debug.Adorner
        {
            internal readonly CheckedExpr checks;

            internal SemanticAdorner(CheckedExpr checks)
            {
                this.checks = checks;
            }

            public string GetMetadata(object elem)
            {
                if (!(elem is Expr))
                {
                    return "";
                }

                StringBuilder result = new StringBuilder();
                Expr e = (Expr)elem;
                Type t = checks.TypeMap[e.Id];
                if (t != null)
                {
                    result.Append("~");
                    result.Append(Types.FormatCheckedType(t));
                }

                switch (e.ExprKindCase)
                {
                    case Expr.ExprKindOneofCase.IdentExpr:
                    case Expr.ExprKindOneofCase.CallExpr:
                    case Expr.ExprKindOneofCase.StructExpr:
                    case Expr.ExprKindOneofCase.SelectExpr:
                        Reference @ref = checks.ReferenceMap[e.Id];
                        if (@ref != null)
                        {
                            if (@ref.OverloadId.Count == 0)
                            {
                                result.Append("^").Append(@ref.Name);
                            }
                            else
                            {
                                for (int i = 0; i < @ref.OverloadId.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        result.Append("^");
                                    }
                                    else
                                    {
                                        result.Append("|");
                                    }

                                    result.Append(@ref.OverloadId[i]);
                                }
                            }
                        }

                        break;
                }

                return result.ToString();
            }
        }

        /// <summary>
        /// Print returns a string representation of the Expr message, annotated with types from the
        /// CheckedExpr. The Expr must be a sub-expression embedded in the CheckedExpr.
        /// </summary>
        public static string Print(Expr e, CheckedExpr checks)
        {
            SemanticAdorner a = new SemanticAdorner(checks);
            return Debug.ToAdornedDebugString(e, a);
        }
    }
}