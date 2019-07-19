using System;
using System.Collections.Generic;
using System.Linq;

namespace ZenSoft.Dotnet.Utils.Collections
{
    /// <summary>
    /// ICollection related extension methods.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Gets the comma delimiter string, depending on whether or not a space has to be added after it
        /// </summary>
        /// <param name="addSpaceAfterComma">Whether or not to add a space after the comma delimiter</param>
        /// <returns>A string with the comma delimiter. If <paramref name="addSpaceAfterComma"/> is true, a 
        /// space is added to the end of the returned string.</returns>
        private static string GetCommaDelimiter(bool addSpaceAfterComma)
        {
            var delimiter = ",";

            if (addSpaceAfterComma)
                delimiter += " ";

            return delimiter;
        }

        /// <summary>
        /// Returns a comma-separated string containing the values within this collection instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements on the collection</typeparam>
        /// <param name="collection">The collection instance</param>
        /// <param name="addSpaceAfterComma">Defines whether or not a space will be added after the comma (,) character. Default = false.</param>
        /// <param name="returnNullIfEmpty">Defines what will be returned in case the instance collection is empty. Pass true to return
        /// null and false to return an empty string. Default = false.</param>
        /// <returns>A comma-separated string containing the values within this collection instance. Or either null or empty string 
        /// (depends on the parameter <paramref name="returnNullIfEmpty"/> if the instance collection is empty</returns>
        public static string ToCommmaSeparatedString<TSource>(this ICollection<TSource> collection, bool addSpaceAfterComma = false, bool returnNullIfEmpty = false)
        {
            if (CollectionHelper.IsNullOrEmpty(collection))
                return returnNullIfEmpty ? null : string.Empty;

            return string.Join(GetCommaDelimiter(addSpaceAfterComma), collection.ToArray());
        }

        /// <summary>
        /// Returns a comma-separated string containing the values within this collection instance, filtered by the <paramref name="wherePredicate"/> predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements on the collection</typeparam>
        /// <param name="collection">The collection instance</param>
        /// <param name="wherePredicate">The predicate used for filtering the values</param>
        /// <param name="addSpaceAfterComma">Defines whether or not a space will be added after the comma (,) character. Default = false.</param>
        /// <param name="returnNullIfEmpty">Defines what will be returned in case the instance collection is empty. Pass true to return
        /// null and false to return an empty string.</param>
        /// <returns>A comma-separated string containing the values within this collection instance. Or either null or empty string 
        /// (depends on the parameter <paramref name="returnNullIfEmpty"/> if the instance collection is empty</returns>
        public static string ToCommmaSeparatedString<TSource>(this ICollection<TSource> collection, Func<TSource, bool> wherePredicate, bool addSpaceAfterComma = false, bool returnNullIfEmpty = false)
        {
            if (CollectionHelper.IsNullOrEmpty(collection))
                return returnNullIfEmpty ? null : string.Empty;

            return string.Join(GetCommaDelimiter(addSpaceAfterComma), collection.Where(wherePredicate).ToArray());
        }

        /// <summary>
        /// Returns a comma-separated string containing the values specified by the <paramref name="selectorPredicate"/> predicate from 
        /// within this collection instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements on the collection</typeparam>
        /// <typeparam name="TResult">The type of the result value specified in the <paramref name="selectorPredicate"/> parameter</typeparam>
        /// <param name="collection">The collection instance</param>
        /// <param name="selectorPredicate">The predicate specifing the member to be used as the value from the collection</param>
        /// <param name="addSpaceAfterComma">Defines whether or not a space will be added after the comma (,) character. Default = false.</param>
        /// <param name="returnNullIfEmpty">Defines what will be returned in case the instance collection is empty. Pass true to return
        /// null and false to return an empty string.</param>
        /// <returns>A comma-separated string containing the values within this collection instance. Or either null or empty string 
        /// (depends on the parameter <paramref name="returnNullIfEmpty"/> if the instance collection is empty</returns>
        public static string ToCommmaSeparatedString<TSource, TResult>(this ICollection<TSource> collection, Func<TSource, TResult> selectorPredicate, bool addSpaceAfterComma = false, bool returnNullIfEmpty = false)
        {
            if (CollectionHelper.IsNullOrEmpty(collection))
                return returnNullIfEmpty ? null : string.Empty;

            return string.Join(GetCommaDelimiter(addSpaceAfterComma), collection.Select(selectorPredicate).ToArray());
        }

        /// <summary>
        /// Returns a comma-separated string containing the values specified by the <paramref name="selectorPredicate"/> predicate from 
        /// within this collection instance, filtered by the <paramref name="wherePredicate"/> predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements on the collection</typeparam>
        /// <typeparam name="TResult">The type of the result value specified in the <paramref name="selectorPredicate"/> parameter</typeparam>
        /// <param name="collection">The collection instance</param>
        /// <param name="wherePredicate">The predicate used for filtering the values</param>
        /// <param name="selectorPredicate">The predicate specifing the member to be used as the value from the collection</param>
        /// <param name="addSpaceAfterComma">Defines whether or not a space will be added after the comma (,) character. Default = false.</param>
        /// <param name="returnNullIfEmpty">Defines what will be returned in case the instance collection is empty. Pass true to return
        /// null and false to return an empty string.</param>
        /// <returns>A comma-separated string containing the values within this collection instance. Or either null or empty string 
        /// (depends on the parameter <paramref name="returnNullIfEmpty"/> if the instance collection is empty</returns>
        public static string ToCommmaSeparatedString<TSource, TResult>(this ICollection<TSource> collection, Func<TSource, bool> wherePredicate, Func<TSource, TResult> selectorPredicate, bool addSpaceAfterComma = false, bool returnNullIfEmpty = false)
        {
            if (CollectionHelper.IsNullOrEmpty(collection))
                return returnNullIfEmpty ? null : string.Empty;

            return string.Join(GetCommaDelimiter(addSpaceAfterComma), collection.Where(wherePredicate).Select(selectorPredicate).ToArray());
        }
    }
}