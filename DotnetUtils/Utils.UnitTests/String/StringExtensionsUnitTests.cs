using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenSoft.Dotnet.Utils.String;

namespace ZenSoft.Dotnet.Utils.UnitTests.String
{
    [TestClass]
    public class StringExtensionsUnitTests
    {
        [TestMethod]
        public void CommonUtilities_ToIntEnumerable_EmptyStringReturnsEmptyList()
        {
            // Arrange
            var myString = string.Empty;

            // Act
            var res = myString.ToIntEnumerable();

            // Assert
            Assert.IsNotNull(res);
            Assert.IsFalse(res.Any());
        }

        [TestMethod]
        public void CommonUtilities_ToIntEnumerable_NullStringReturnsEmptyList()
        {
            // Arrange
            string myString = null;

            // Act
            var res = myString.ToIntEnumerable();

            // Assert
            Assert.IsNotNull(res);
            Assert.IsFalse(res.Any());
        }

        [TestMethod]
        public void CommonUtilities_ToIntEnumerable_StringWithNoSeparatorReturnsListWithSameValue()
        {
            // Arrange
            var myString = "12365";

            // Act
            var res = myString.ToIntEnumerable();

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.First() == 12365);
        }

        [TestMethod]
        public void CommonUtilities_ToIntEnumerable_StringWithSeparatorReturnsListWithAllValues()
        {
            // Arrange
            var myString = "123, 456, 789";

            // Act
            var res = myString.ToIntEnumerable();

            // Assert
            Assert.IsNotNull(res);
            var list = res.ToList();
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list[0] == 123);
            Assert.IsTrue(list[1] == 456);
            Assert.IsTrue(list[2] == 789);            
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CommonUtilities_ToIntEnumerable_StringWithInvalidNumberThrowsException()
        {
            // Arrange
            var myString = "123, abc, 789";

            // Act
            var res = myString.ToIntEnumerable();

            // Assert
            var list = res.ToList();
        }

        [TestMethod]
        public void CommonUtilities_ToIntEnumerable_StringWithDifferentSeparatorAndSpacesReturnsValidResult()
        {
            // Arrange
            var myString = "1- 2 - 3";

            // Act
            var res = myString.ToIntEnumerable('-');

            // Assert (not needed)
            Assert.IsNotNull(res);
            var list = res.ToList();
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list[0] == 1);
            Assert.IsTrue(list[1] == 2);
            Assert.IsTrue(list[2] == 3);
        }

        [TestMethod]
        public void CommonUtilities_ToStringEnumerable_EmptyStringReturnsEmptyList()
        {
            // Arrange
            var myString = string.Empty;

            // Act
            var res = myString.ToStringEnumerable();

            // Assert
            Assert.IsNotNull(res);
            Assert.IsFalse(res.Any());
        }

        [TestMethod]
        public void CommonUtilities_ToStringEnumerable_ValidStringReturnsValidList()
        {
            // Arrange
            var myString = "1,2,3";

            // Act
            var res = myString.ToStringEnumerable();

            // Assert
            Assert.IsNotNull(res);
            var list = res.ToList();
            Assert.IsTrue(list[0] == "1");
            Assert.IsTrue(list[1] == "2");
            Assert.IsTrue(list[2] == "3");
        }

        [TestMethod]
        public void CommonUtilities_ToStringEnumerable_StringWithEmptyItemReturnsListWithEmptyItem()
        {
            // Arrange
            var myString = ",1,2,3,,";

            // Act
            var res = myString.ToStringEnumerable(false);

            // Assert
            Assert.IsNotNull(res);
            var list = res.ToList();
            Assert.IsTrue(list[0] == "");
            Assert.IsTrue(list[1] == "1");
            Assert.IsTrue(list[2] == "2");
            Assert.IsTrue(list[3] == "3");
            Assert.IsTrue(list[4] == "");
            Assert.IsTrue(list[5] == "");
        }

        [TestMethod]
        public void CommonUtilities_ToStringEnumerable_StringWithEmptyItemReturnsListWithoutEmptyItemDefaultParam()
        {
            // Arrange
            var myString = ",1,2,3";

            // Act
            var res = myString.ToStringEnumerable(); // removeEmptyItem default = true

            // Assert
            Assert.IsNotNull(res);
            var list = res.ToList();
            Assert.IsTrue(list[0] == "1");
            Assert.IsTrue(list[1] == "2");
            Assert.IsTrue(list[2] == "3");
        }

        [TestMethod]
        public void CommonUtilities_ToStringEnumerable_StringWithEmptyItemReturnsListWithoutEmptyItem()
        {
            // Arrange
            var myString = ",1,2,3";

            // Act
            var res = myString.ToStringEnumerable(true);

            // Assert
            Assert.IsNotNull(res);
            var list = res.ToList();
            Assert.IsTrue(list[0] == "1");
            Assert.IsTrue(list[1] == "2");
            Assert.IsTrue(list[2] == "3");
        }
    }
}
