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
        public void If_I_Try_To_Call_Otherwise_Nothing_Must_Happen()
        {
            Ensure.That("a" == "A").Otherwise();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Throws_Me_A_Specific_Exception()
        {
            Ensure.That("a" == "A").IsTrue().Otherwise().Throw<Exception>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Throws_Me_ArgumentException()
        {
            Ensure.That("a" == "B").IsTrue().Otherwise().Throw<ArgumentException>();
        }

        [TestMethod]        
        public void If_I_Try_To_Ensure_A_False_Condition_With_IsFalse_It_Must_Not_Throw_An_Exception()
        {
            Ensure.That("a" == "B").IsFalse().Otherwise().Throw<ArgumentException>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Ensure_A_True_Condition_With_IsFalse_It_Must_Not_Throw_An_Exception()
        {
            Ensure.That(1 + 1 == 2).IsFalse().Otherwise().Throw<ArgumentException>();
        }

        [TestMethod]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Throws_Me_A_Specific_Exception_With_Message()
        {
            string expected = "Exception message text!";
            try
            {
                Ensure.That("a" == "A").IsTrue().Otherwise().Throw<Exception>(expected);
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expected, ex.Message);
            }
        }
    }
}