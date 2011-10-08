using System;
using Amarok.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Extensions
{
    /// <summary>
    /// Summary description for StringExtensionsTests
    /// </summary>
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void If_I_Try_To_Verify_A_Valid_String_IsGuid_It_Must_Returns_True()
        {
            string guid = Guid.NewGuid().ToString();
            bool result = guid.IsGuid();
            //
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Verify_A_Null_String_IsGuid_It_Must_Throws_An_Exception()
        {
            ((string)null).IsGuid();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Verify_An_Empty_String_IsGuid_It_Must_Throws_An_Exception()
        {
            string.Empty.IsGuid();
        }

        [TestMethod]
        public void If_I_Try_To_Verify_An_Invalid_String_IsGuid_It_Must_Returns_False()
        {
            string value = "not a guid";
            bool result = value.IsGuid();
            //
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void If_I_Try_To_Verify_A_Guid_With_Curly_Brackets_It_Must_Returns_True()
        {
            string value = "{0A7C4C69-BFBC-4E3E-A25D-2BD207CFB098}";
            bool result = value.IsGuid();
            //
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void If_I_Try_To_Verify_A_Guid_With_Curly_Brackets_Only_In_Beginning_It_Must_Returns_True()
        {
            string value = "{0A7C4C69-BFBC-4E3E-A25D-2BD207CFB098";
            bool result = value.IsGuid();
            //
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void If_I_Try_To_Verify_A_Guid_With_Curly_Brackets_Only_In_The_End_It_Must_Returns_True()
        {
            string value = "0A7C4C69-BFBC-4E3E-A25D-2BD207CFB098}";
            bool result = value.IsGuid();
            //
            Assert.IsTrue(result);
        }
    }
}
