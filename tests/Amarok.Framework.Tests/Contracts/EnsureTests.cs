using System;
using Amarok.Framework.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Contracts
{
    [TestClass]
    public class EnsureTests
    {
        //Ensure.AllParameters().ToBeRequired();

        [TestMethod]
        public void If_I_Try_To_Ensure_A_True_Condition_It_Must_Continues()
        {
            Ensure.That(x => 1 > 0).IsTrue();            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Throws_An_Exception()
        {
            Ensure.That(x => 1 <= 0).IsTrue();
        }

        [TestMethod]
        public void If_I_Try_To_Ensure_A_False_Condition_It_Must_Continues()
        {
            Ensure.That(x => "a" == "A").IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void If_I_Try_To_Deny_A_True_Condition_It_Must_Throws_An_Exception()
        {
            Ensure.That(x => "A" == "A").IsFalse();            
        }        
    }
}
