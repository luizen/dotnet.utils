using System;
using System.Collections.Generic;
using System.Linq;

namespace Volvo.QFS.Utilities.String
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
        /// Transforms a string containing comma-separated numbers into a List of int values.
        /// </summary> 
        /// <param name="str">The string instance</param>
        /// <exception cref="FormatException">When any of the values on the string is not in a valid Int format</exception>
        /// <exception cref="OverflowException">When any of the values on the string represents a number less than MinValue or greater than MaxValue.</exception>
        /// <returns>A List of integer numbers extracted from this comma-separated instance.</returns>
        public static IList<int> ToIntList(this string str)
        {
            return str.ToIntList(DefaultSeparator);
        }

        /// <summary>
        /// Transforms a string containing numbers, separated by the given <paramref name="separator"/>, into a List of int values.
        /// </summary> 
        /// <param name="str">The string instance</param>
        /// <param name="separator">The saparator used to spliting the string into.</param>
        /// <exception cref="FormatException">When any of the values on the string is not in a valid Int format</exception>
        /// <exception cref="OverflowException">When any of the values on the string represents a number less than MinValue or greater than MaxValue.</exception>
        /// <returns>A List of integer numbers extracted from this instance.</returns>
        public static IList<int> ToIntList(this string str, char separator)
        {
            var result = new List<int>();

            if (!string.IsNullOrWhiteSpace(str))
            {
                var strSplit = str.Split(separator);
                if (strSplit.Any())
                    result = strSplit.Select(i => int.Parse(i)).ToList();
            }

            return result;
        }

        /// <summary>
        /// Transforms a string containing comma-separated values into a List of string values.
        /// </summary> 
        /// <param name="str">The string instance</param>
        /// <param name="removeEmptyEntries">True (default) to remove empty items from the result list. False to keep empty values in the result.</param>
        /// <returns>A List of string values extracted from this comma-separated instance.</returns>
        public static IList<string> ToStringList(this string str, bool removeEmptyEntries = true)
        {
            var result = new List<string>();

            StringSplitOptions splitOptions = removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            
            if (!string.IsNullOrWhiteSpace(str))
            {
                var strSplit = str.Split(new char[] { DefaultSeparator }, splitOptions);
                if (strSplit.Any())
                    result = strSplit.ToList();
            }

            return result;
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
