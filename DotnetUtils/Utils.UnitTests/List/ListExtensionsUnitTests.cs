using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenSoft.Dotnet.Utils.List;

namespace ZenSoft.Dotnet.Utils.UnitTests.List
{
    [TestClass]
    public class ListExtensionsUnitTests
    {
        
        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_EmptyListReturnsEmptyString()
        {
            // Arrange
            IList<int> list = new List<int>();

            // Act
            var result = list.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(result.Equals(string.Empty));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_EmptyListReturnsNull()
        {
            // Arrange
            IList<int> list = new List<int>();

            // Act
            var result = list.ToCommmaSeparatedString(x => x, returnNullIfEmpty: true);

            // Assert
            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void CommonUtilities_CommonUtilities_ToCommmaSeparatedString_NonEmptyListReturnsValidValues()
        {
            // Arrange
            IList<int> list = new List<int>() { 1, 2, 3 };

            // Act
            var result = list.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals("1,2,3"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_NonEmptyListReturnsValidValuesWithSpaceAfterComma()
        {
            // Arrange
            IList<int> list = new List<int>() { 1, 2, 3 };

            // Act
            var result = list.ToCommmaSeparatedString(x => x, addSpaceAfterComma:true);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals("1, 2, 3"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_NonEmptyListReturnsFilteredElements()
        {
            // Arrange
            IList<int> list = new List<int>() { 1, 2, 3 };

            // Act
            var result = list.ToCommmaSeparatedString(x => x > 2);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals("3"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_ListOfBlankStringsReturnsBlankItems()
        {
            // Arrange
            IList<string> list = new List<string>() { " ", " ", " " };

            // Act
            var result = list.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals(" , , "));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_ListOfEmptyStringsReturnsEmptyItems()
        {
            // Arrange
            IList<string> list = new List<string>() { "", "", "" };

            // Act
            var result = list.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals(",,"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_ListOfEmptyAndNotEmptyStringsReturnsCorrectItems()
        {
            // Arrange
            IList<string> list = new List<string>() { "", "1", "", "4", "" };

            // Act
            var result = list.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals(",1,,4,"));
        }
    }
}
