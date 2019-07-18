using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenSoft.Dotnet.Utils.List;

namespace ZenSoft.Dotnet.Utils.UnitTests.List
{
    [TestClass]
    public class ListHelperUnitTests
    {
        [TestMethod]
        public void CommonUtilities_IsNullOrEmpty_EmptyListReturnsTrue()
        {
            // Arrange
            IList<int> list = new List<int>();

            // Act
            bool result = ListHelper.IsNullOrEmpty(list);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CommonUtilities_IsNullOrEmpty_NullListReturnsTrue()
        {
            // Arrange
            IList<int> list = null;

            // Act
            bool result = ListHelper.IsNullOrEmpty(list);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CommonUtilities_IsNullOrEmpty_NotEmptyListReturnsFalse()
        {
            // Arrange
            IList<int> list = new List<int>() {0, 1, 2, 3};

            // Act
            bool result = ListHelper.IsNullOrEmpty(list);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
