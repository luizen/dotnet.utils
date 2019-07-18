using System.Collections.Generic;

namespace ZenSoft.Dotnet.Utils.List
{
    /// <summary>
    /// Helper for the classes implementing IList
    /// </summary>
    public static class ListHelper
    {
        /// <summary>
        /// Checks if a list instance is null or empty
        /// </summary>
        /// <param name="list">The list to be verified.</param>
        /// <returns>True if the list is null or empty. False if not null and also not empty</returns>
        public static bool IsNullOrEmpty<T>(IList<T> list)
        {
            return (list == null || list.Count <= 0);
        }
    }
}