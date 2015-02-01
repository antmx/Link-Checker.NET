using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Netricity.Common
{
	/// <summary>
	/// System.String extension methods.
	/// </summary>
	public static class StringExtensions
	{
		public static string GetValueOrDefault(this string str, string defaultStr="", bool canBeWhitespaceOnly = false)
		{
			if (HasValue(str, canBeWhitespaceOnly))
				return str;

			return defaultStr;
		}

		public static bool HasValue(this string str, bool canBeWhitespaceOnly = false)
		{
			if (str == null || str.Length == 0)
				return false;

			return canBeWhitespaceOnly || str.Trim().Length > 0;
		}

		public static string ReplaceCI(this string str, string oldValue, string newValue)
		{
			if (str == null || oldValue == null)
				return str;

			if (newValue == null)
				newValue = string.Empty;

			var replaced = Regex.Replace(
				str,
				Regex.Escape(oldValue),
				Regex.Escape(newValue));

			return Regex.Unescape(replaced);
		}

		public static bool ContainsCI(this string str, params string[] values)
		{
			if (str == null)
				return false;

			return Contains(str, true, values);
		}

		/// <summary>
		/// Returns a value indicating if the string matches the specified value, using a case-insensitive comparison.
		/// </summary>
		/// <param name="str">The string.</param>
		/// <param name="other">The value to compare with.</param>
		public static bool EqualsCI(this string str, string other)
		{
			if (str == null)
				return false;

			//return EqualsIgnoreCase(str, value);
			bool equal = string.Equals(str, other, StringComparison.OrdinalIgnoreCase);

			return equal;
		}

		public static bool StartsWithCI(this string str, string value)
		{
			if (str == null)
				return false;

			return str.StartsWith(value, StringComparison.OrdinalIgnoreCase);
		}

		public static bool EndsWithCI(this string str, string value)
		{
			if (str == null)
				return false;

			return str.EndsWith(value, StringComparison.OrdinalIgnoreCase);
		}

		public static string Left(this string str, int length)
		{
			if (str.Length < length)
			{
				return str;
			}

			return str.Substring(0, length);
		}

		public static string Lower(this string str)
		{
			if (str != null)
			{
				return str.ToLower();
			}
			return null;
		}

		public static string Right(this string str, int length)
		{
			if (str == null || str.Length < length)
			{
				return str;
			}
			return str.Substring(str.Length - length);
		}

		public static string SplitCaps(this string str)
		{
			if (str == null)
				return null;

			var output = new StringBuilder("");

			foreach (char letter in str)
			{
				if (Char.IsUpper(letter) && output.Length > 0)
					output.Append(" " + letter);
				else
					output.Append(letter);
			}

			return output.ToString();
		}

		/// <summary>
		/// Returns the string converted to PascalCase.
		/// </summary>
		/// <param name="str">The string.</param>
		public static string ToPascalCase(this string str)
		{
			if (str == null)
				return null;

			int idx = 0; // index in str
			bool isFirst = true; // first letter flag
			string o = string.Empty; // output string
			string whitespaceChars = string.Empty + (char)13 + (char)10 + (char)9 + (char)160 + ' '; // characters considered as white space

			while (idx < str.Length)
			{
				char c = str[idx];

				if (isFirst)
				{
					o += Char.ToUpper(c);
					isFirst = false;
				}
				else
				{
					o += Char.ToLower(c);
				}

				if (whitespaceChars.Contains(c))
					isFirst = true;

				idx++;
			}

			return o;
		}

		/// <summary>
		/// Chops the start off a string. Case-insensitive.
		/// </summary>
		/// <param name="str">The text.</param>
		/// <param name="start">The start.</param>
		/// <returns></returns>
		public static string ChopStart(this string str, string start)
		{
			if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(start) && str.ToLower().StartsWith(start.ToLower(), true, CultureInfo.InvariantCulture))
			{
				return str.Substring(start.Length);
			}
			return str;
		}

		/// <summary>
		/// Chops the end off a string. Case-insensitive.
		/// </summary>
		/// <param name="str">The text.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static string ChopEnd(this string str, string end)
		{
			if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(end) && str.ToLower().EndsWith(end.ToLower(), true, CultureInfo.InvariantCulture))
			{
				int length = str.LastIndexOf(end, StringComparison.InvariantCultureIgnoreCase);
				return str.Substring(0, length);
			}
			return str;
		}

		public static string[] ConvertCsvToStringArray(this string str, char separator = ',', StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
		{
			if (str == null)
				return null;

			var array = str.Split(new[] { separator }, options);

			return array;
		}

		public static bool Contains(this string str, bool ignoreCase, params string[] args)
		{
			if (str != null && args != null)
			{
				foreach (string arg in args)
				{
					if (arg != null && arg.Length <= str.Length)
					{
						if (ignoreCase)
						{
							if (str.IndexOf(arg, StringComparison.OrdinalIgnoreCase) > -1)
							{
								return true;
							}
						}
						else if (str.IndexOf(arg) > -1)
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		public static object Convert(this string str, Type toType)
		{
			object objectValue;
			bool canConvert;
			var converter = TypeDescriptor.GetConverter(toType);

			if (converter == null || !converter.CanConvertFrom(typeof(string)))
			{
				canConvert = false;
			}
			else
			{
				canConvert = true;
			}
			
			if (canConvert)
			{
				objectValue = RuntimeHelpers.GetObjectValue(converter.ConvertFrom(str));
			}
			else
			{
				objectValue = RuntimeHelpers.GetObjectValue(System.Convert.ChangeType(str, toType));
			}

			object obj = objectValue;

			return obj;
		}

		public static T Convert<T>(this string str)
		{
			Type objType = typeof(T);
			T objT = (T)Convert(str, objType);
			return objT;
		}

		/// <summary>
		/// Converts the specified string to a value of the given type.
		/// If conversion fails, <paramref name="defaultVal"/> is returned.
		/// </summary>
		/// <typeparam name="T">The type to conver to.</typeparam>
		/// <param name="str">The string to convert.</param>
		/// <param name="defaultVal">The default value for when conversion fails.</param>
		public static T Convert<T>(this string str, T defaultVal)
		{
			Type objType = typeof(T);

			try
			{
				T objT = (T)Convert(str, objType);

				return objT;
			}
			catch (Exception)
			{
				return defaultVal;
			}
		}

		/// <summary>
		/// Strips HTML tags from the giving string, returning just the plain text.
		/// </summary>
		/// <param name="html">A string of HTML.</param>
		public static string StripHtml(this string html)
		{
			if (html == null)
				return null;

			string pattern = "<(.|\\n)*?>";

			return Regex.Replace(html, pattern, string.Empty);
		}
	}
}
