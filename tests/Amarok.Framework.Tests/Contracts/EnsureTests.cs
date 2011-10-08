using System;
using Amarok.Framework.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Contracts
{
    [TestClass]
    public class EnsureTests
    {
        [TestMethod]
        public void If_I_Try_To_Ensure_A_True_Condition_It_Must_Continues()
        {
            Ensure.That(1 > 0).IsTrue();
        }        

        [TestMethod]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Continues()
        {
            Ensure.That("a" == "A").IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Throws_Me_A_Specific_Exception()
        {
            Ensure.That("a" == "A").IsTrue().Otherwise.Throw<Exception>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Throws_Me_ArgumentException()
        {
            Ensure.That("a" == "B").IsTrue().Otherwise.Throw<ArgumentException>();
        }

        [TestMethod]        
        public void If_I_Try_To_Ensure_A_False_Condition_With_IsFalse_It_Must_Not_Throw_An_Exception()
        {
            Ensure.That("a" == "B").IsFalse().Otherwise.Throw<ArgumentException>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Ensure_A_True_Condition_With_IsFalse_It_Must_Not_Throw_An_Exception()
        {
            Ensure.That(1 + 1 == 2).IsFalse().Otherwise.Throw<ArgumentException>();
        }

        [TestMethod]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Throws_Me_A_Specific_Exception_With_Message()
        {
            string expected = "Exception message text!";
            try
            {
                Ensure.That("a" == "A").IsTrue().Otherwise.Throw<Exception>(expected);
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expected, ex.Message);
            }
        }

        [TestMethod]
        public void If_I_Try_To_Ensure_A_Variable_Is_Not_Null_It_Must_Not_Throws_An_Exception()
        {
            int foo = 23;
            Ensure.That(foo).IsNotNull().Otherwise.Throw<NullReferenceException>();
        }

        [TestMethod]
        public void If_I_Try_To_Ensure_An_Empty_String_Is_Not_Null_It_Must_Not_Throws_An_Exception()
        {
            Ensure.That(String.Empty).IsNotNull().Otherwise.Throw<NullReferenceException>();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void If_I_Try_To_Ensure_A_Null_Variable_To_Be_Not_Null_It_Must_Throws_An_Exception()
        {
            string foo = null;
            Ensure.That(foo).IsNotNull().Otherwise.Throw<NullReferenceException>();
        }

        [TestMethod]
        public void If_I_Try_To_Ensure_A_String_With_Value_It_Must_Not_Throws_An_Exception()
        {
            string foo = "foo value";
            Ensure.That(foo).HasValue().Otherwise.Throw<NotSupportedException>();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void If_I_Try_To_Ensure_An_Empty_String_With_Value_It_Must_Throws_An_Exception()
        {
            Ensure.That(String.Empty).HasValue().Otherwise.Throw<NotSupportedException>();
        }

        [TestMethod]
        public void If_I_Try_To_Ensure_All_Elements_Of_An_Array_Are_Not_Null_It_Must_Not_Throws_Exception()
        {
            object[] values = { "foo", 5, DateTime.Now, new System.Text.StringBuilder() };
            Ensure.That(values).AreAllNotNull().Otherwise.Throw<NotSupportedException>();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void If_I_Try_To_Ensure_Null_Elements_Of_An_Array_Are_Not_Null_It_Must_Throws_Exception()
        {
            object[] values = { "foo", null, DateTime.Now, new System.Text.StringBuilder() };
            Ensure.That(values).AreAllNotNull().Otherwise.Throw<NullReferenceException>();
        }
    }
}