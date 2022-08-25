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
using System.Text;

namespace Cel.Common
{

	/// <summary>
	/// Note: This class is called {@code Error} in Go, but that name is occupied by {@code
	/// java.lang.Error}.
	/// </summary>
	public sealed class CelError : IComparable<CelError>
	{
	  private const char dot = '.';
	  private const char ind = '^';
	  // private static final char wideDot = '\uFF0E'; // result of Go's width.Widen(".")
	  // private static final char wideInd = '\uFF3E'; // result of Go's width.Widen("^")
	  private readonly Location location;
	  private readonly string message;

	  public CelError(Location location, string message)
	  {
		this.location = location;
		this.message = message;
	  }

	  public Location Location
	  {
		  get
		  {
			return location;
		  }
	  }

	  public string Message
	  {
		  get
		  {
			return message;
		  }
	  }

	  public int CompareTo(CelError o)
	  {
		int r = location.CompareTo(o.location);
		if (r == 0)
		{
		  r = string.CompareOrdinal(message, o.message);
		}
		return r;
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
		CelError error = (CelError) o;
		return object.Equals(location, error.location) && object.Equals(message, error.message);
	  }

	  public override int GetHashCode()
	  {
		return HashCode.Combine(location, message);
	  }

	  public override string ToString()
	  {
		return "Error{" + "location=" + location + ", message='" + message + '\'' + '}';
	  }

	  /// <summary>
	  /// ToDisplayString decorates the error message with the source location. </summary>
	  public string ToDisplayString(Source source)
	  {
		StringBuilder result = new StringBuilder(string.Format("ERROR: {0}:{1:D}:{2:D}: {3}", source.Description(), location.Line(), location.Column() + 1, message));

		string snippet = source.Snippet(location.Line());
		if (!string.ReferenceEquals(snippet, null))
		{
		  snippet = snippet.Replace('\t', ' ');
		  result.Append("\n | ").Append(snippet);

		  // The original Go code does some wild-guessing about the displayed width of a character,
		  // but it blindly assumes that a UTF-8 _encoding_ length > 1 byte means that the character
		  // needs two columns to display. That's not correct... think: ä ö ü ß € etc etc etc
		  // If we want have nicer (wide) dots, we might think of interpreting the string in a more
		  // sophisticated way, maybe use jline's WCWidth, but that one is also quite rudimentary wrt
		  // code-blocks (e.g. doesn't know about emojis).
		  result.Append("\n | ");
		  for (int i = 0; i < location.Column(); i++)
		  {
			result.Append(dot);
		  }
		  result.Append(ind);
		}
		return result.ToString();
	  }
	}

}