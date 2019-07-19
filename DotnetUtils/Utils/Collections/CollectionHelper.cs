using System.Collections.Generic;

namespace ZenSoft.Dotnet.Utils.Collections
{
    /// <summary>
    /// Helper for the classes implementing ICollection
    /// </summary>
    public static class CollectionHelper
    {
        /// <summary>
        /// Checks if a collection instance is null or empty
        /// </summary>
        /// <param name="collection">The collection to be verified.</param>
        /// <returns>True if the collection is null or empty. False if not null and also not empty</returns>
        public static bool IsNullOrEmpty<T>(ICollection<T> collection)
        {
            return (collection == null || collection.Count <= 0);
        }
    }
}