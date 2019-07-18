using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Volvo.QFS.Utilities.String;

namespace Volvo.QFS.Utilities.UnitTests.String
{
    [TestClass]
    public class StringExtensionsUnitTests
    {
        [TestMethod]
        public void CommonUtilities_ToIntList_EmptyStringReturnsEmptyList()
        {
            // Arrange
            var myString = string.Empty;

            // Act
            IList<int> result = myString.ToIntList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CommonUtilities_ToIntList_NullStringReturnsEmptyList()
        {
            // Arrange
            string myString = null;

            // Act
            IList<int> result = myString.ToIntList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CommonUtilities_ToIntList_StringWithNoSeparatorReturnsListWithSameValue()
        {
            // Arrange
            var myString = "12365";

            // Act
            IList<int> result = myString.ToIntList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == 12365);
        }

        [TestMethod]
        public void CommonUtilities_ToIntList_StringWithSeparatorReturnsListWithAllValues()
        {
            // Arrange
            var myString = "123, 456, 789";

            // Act
            IList<int> result = myString.ToIntList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0] == 123);
            Assert.IsTrue(result[1] == 456);
            Assert.IsTrue(result[2] == 789);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CommonUtilities_ToIntList_StringWithInvalidNumberThrowsException()
        {
            // Arrange
            var myString = "123, abc, 789";

            // Act
            myString.ToIntList();

            // Assert (not needed)
        }

        [TestMethod]
        public void CommonUtilities_ToIntList_StringWithDifferentSeparatorAndSpacesReturnsValidResult()
        {
            // Arrange
            var myString = "1- 2 - 3";

            // Act
            IList<int> result = myString.ToIntList('-');

            // Assert (not needed)
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0] == 1);
            Assert.IsTrue(result[1] == 2);
            Assert.IsTrue(result[2] == 3);
        }

        [TestMethod]
        public void CommonUtilities_ToStringList_EmptyStringReturnsEmptyList()
        {
            // Arrange
            var myString = string.Empty;

            // Act
            IList<string> result = myString.ToStringList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CommonUtilities_ToStringList_ValidStringReturnsValidList()
        {
            // Arrange
            var myString = "1,2,3";

            // Act
            IList<string> result = myString.ToStringList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == "1");
            Assert.IsTrue(result[1] == "2");
            Assert.IsTrue(result[2] == "3");
        }

        [TestMethod]
        public void CommonUtilities_ToStringList_StringWithEmptyItemReturnsListWithEmptyItem()
        {
            // Arrange
            var myString = ",1,2,3,,";

            // Act
            IList<string> result = myString.ToStringList(false);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == "");
            Assert.IsTrue(result[1] == "1");
            Assert.IsTrue(result[2] == "2");
            Assert.IsTrue(result[3] == "3");
            Assert.IsTrue(result[4] == "");
            Assert.IsTrue(result[5] == "");
        }

        [TestMethod]
        public void CommonUtilities_ToStringList_StringWithEmptyItemReturnsListWithoutEmptyItemDefaultParam()
        {
            // Arrange
            var myString = ",1,2,3";

            // Act
            IList<string> result = myString.ToStringList(); // removeEmptyItem default = true

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == "1");
            Assert.IsTrue(result[1] == "2");
            Assert.IsTrue(result[2] == "3");
        }

        [TestMethod]
        public void CommonUtilities_ToStringList_StringWithEmptyItemReturnsListWithoutEmptyItem()
        {
            // Arrange
            var myString = ",1,2,3";

            // Act
            IList<string> result = myString.ToStringList(true);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == "1");
            Assert.IsTrue(result[1] == "2");
            Assert.IsTrue(result[2] == "3");
        }
    }
}
