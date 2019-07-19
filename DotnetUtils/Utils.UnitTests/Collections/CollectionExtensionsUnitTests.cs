using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenSoft.Dotnet.Utils.Collections;

namespace ZenSoft.Dotnet.Utils.UnitTests.Collections
{
    [TestClass]
    public class CollectionExtensionsUnitTests
    {
        
        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_EmptyCollectionReturnsEmptyString()
        {
            // Arrange
            ICollection<int> col = new Collection<int>();

            // Act
            var result = col.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(result.Equals(string.Empty));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_EmptyCollectionReturnsNull()
        {
            // Arrange
            ICollection<int> col = new Collection<int>();

            // Act
            var result = col.ToCommmaSeparatedString(x => x, returnNullIfEmpty: true);

            // Assert
            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void CommonUtilities_CommonUtilities_ToCommmaSeparatedString_NonEmptyCollectionReturnsValidValues()
        {
            // Arrange
            ICollection<int> col = new Collection<int>() { 1, 2, 3 };

            // Act
            var result = col.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals("1,2,3"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_NonEmptyCollectionReturnsValidValuesWithSpaceAfterComma()
        {
            // Arrange
            ICollection<int> col = new Collection<int>() { 1, 2, 3 };

            // Act
            var result = col.ToCommmaSeparatedString(x => x, addSpaceAfterComma:true);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals("1, 2, 3"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_NonEmptyCollectionReturnsFilteredElements()
        {
            // Arrange
            ICollection<int> col = new Collection<int>() { 1, 2, 3 };

            // Act
            var result = col.ToCommmaSeparatedString(x => x > 2);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals("3"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_CollectionOfBlankStringsReturnsBlankItems()
        {
            // Arrange
            ICollection<string> col = new Collection<string>() { " ", " ", " " };

            // Act
            var result = col.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals(" , , "));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_CollectionOfEmptyStringsReturnsEmptyItems()
        {
            // Arrange
            ICollection<string> col = new Collection<string>() { "", "", "" };

            // Act
            var result = col.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals(",,"));
        }

        [TestMethod]
        public void CommonUtilities_ToCommmaSeparatedString_CollectionOfEmptyAndNotEmptyStringsReturnsCorrectItems()
        {
            // Arrange
            ICollection<string> col = new Collection<string>() { "", "1", "", "4", "" };

            // Act
            var result = col.ToCommmaSeparatedString(x => x);

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Equals(",1,,4,"));
        }
    }
}
