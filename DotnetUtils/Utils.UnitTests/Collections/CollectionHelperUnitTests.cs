using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenSoft.Dotnet.Utils.Collections;
using System.Linq;


namespace ZenSoft.Dotnet.Utils.UnitTests.Collections
{
    [TestClass]
    public class CollectionHelperUnitTests
    {
        [TestMethod]
        public void CommonUtilities_IsNullOrEmpty_EmptyCollectionReturnsTrue()
        {
            // Arrange
            ICollection<int> col = new Collection<int>();

            // Act
            bool result = CollectionHelper.IsNullOrEmpty(col);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CommonUtilities_IsNullOrEmpty_NullCollectionReturnsTrue()
        {
            // Arrange
            ICollection<int> col = null;

            // Act
            bool result = CollectionHelper.IsNullOrEmpty(col);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CommonUtilities_IsNullOrEmpty_NotEmptyCollectionReturnsFalse()
        {
            // Arrange
            ICollection<int> col = new Collection<int>() {0, 1, 2, 3};

            // Act
            bool result = CollectionHelper.IsNullOrEmpty(col);

            // Assert
            Assert.IsFalse(result);
        }      
    }
}
