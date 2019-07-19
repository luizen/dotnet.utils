using System;
using System.Collections.Generic;
using System.Linq;

namespace ZenSoft.Dotnet.Utils.String
{
    /// <summary>
    /// <see cref="System.String"/> related extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The default separator used for 'Split' method usages
        /// </summary>
        public const char DefaultSeparator = ',';

        /// <summary>
        /// Transforms a string containing comma-separated numbers into an enumerable of int values.
        /// </summary> 
        /// <param name="str">The string instance</param>
        /// <exception cref="FormatException">When any of the values on the string is not in a valid Int format</exception>
        /// <exception cref="OverflowException">When any of the values on the string represents a number less than MinValue or greater than MaxValue.</exception>
        /// <returns>An <see cref="IEnumerable{T}"/> of integer numbers extracted from this comma-separated instance.</returns>
        public static IEnumerable<int> ToIntEnumerable(this string str)
        {
            return str.ToIntEnumerable(DefaultSeparator);
        }

        /// <summary>
        /// Transforms a string containing numbers, separated by the given <paramref name="separator"/>, into an enumerable of int values.
        /// </summary> 
        /// <param name="str">The string instance</param>
        /// <param name="separator">The saparator used to spliting the string into.</param>
        /// <exception cref="FormatException">When any of the values on the string is not in a valid Int format</exception>
        /// <exception cref="OverflowException">When any of the values on the string represents a number less than MinValue or greater than MaxValue.</exception>
        /// <returns>An <see cref="IEnumerable{T}"/> of integer numbers extracted from this instance.</returns>
        public static IEnumerable<int> ToIntEnumerable(this string str, char separator)
        {

            if (!string.IsNullOrWhiteSpace(str))
            {
                var strSplit = str.Split(separator);
                if (strSplit.Any())
                    return strSplit.Select(i => int.Parse(i));
            }

            return Enumerable.Empty<int>();
        }

        /// <summary>
        /// Transforms a string containing comma-separated values into an enumerable of string values.
        /// </summary> 
        /// <param name="str">The string instance</param>
        /// <param name="removeEmptyEntries">True (default) to remove empty items from the result list. False to keep empty values in the result.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of string values extracted from this comma-separated instance.</returns>
        public static IEnumerable<string> ToStringEnumerable(this string str, bool removeEmptyEntries = true)
        {
            StringSplitOptions splitOptions = removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            
            if (!string.IsNullOrWhiteSpace(str))
            {
                var strSplit = str.Split(new char[] { DefaultSeparator }, splitOptions);
                if (strSplit.Any())
                    return strSplit.AsEnumerable();
            }

            return Enumerable.Empty<string>();
        }

        /// <summary>
        /// Makes sure every comma character has a space after it.
        /// </summary>
        /// <param name="str">The string instance</param>
        /// <returns>A new string where every comma character is sure to have a space after it.
        /// If <paramref name="str"/> is null, it returns null.</returns>
        /// <remarks>Attention: the resulting string is trimmed!</remarks>
        public static string FixSpaceAfterCommas(this string str)
        {
            return str == null ? str : string.Join(", ", str.Split(',').Select(x => x.Trim()));
        }
    }
}
