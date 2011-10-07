using System;
using System.Collections.Generic;
using Amarok.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Extensions
{
    /// <summary>
    /// Summary description for IListExtensions
    /// </summary>
    [TestClass]
    public class IListExtensionsTests
    {
        public IListExtensionsTests() { }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void If_I_Try_To_Swap_Two_Items_By_Position_Having_Other_Letters_In_Collection()
        {
            IList<char> letters = new List<char> { 'a', 'z', 'h', 'd', };
            letters.Swap<char>(1, 3);

            Assert.IsTrue(letters.IndexOf('z') == 3);
            Assert.IsTrue(letters.IndexOf('d') == 1);            
        }

        [TestMethod]
        public void If_I_Try_To_Swap_Only_Two_Letters()
        {
            IList<char> letters = new List<char> { 'z', 'h', };
            letters.Swap<char>(0, 1);

            Assert.IsTrue(letters.IndexOf('z') == 1);
            Assert.IsTrue(letters.IndexOf('h') == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void If_I_Try_To_Swap_Positions_Nonexistent()
        {
            IList<char> letters = new List<char> { 'z', };
            letters.Swap<char>(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void If_I_Try_To_Swap_First_Position_Less_Than_Zero()
        {
            IList<char> letters = new List<char> { 'z', };
            letters.Swap<char>(-1, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void If_I_Try_To_Swap_Second_Position_Less_Than_Zero()
        {
            IList<char> letters = new List<char> { 'z', 'b' };
            letters.Swap<char>(1, -3);
        }

        [TestMethod]
        public void If_I_Try_To_Swap_The_Same_Position()
        {
            IList<char> letters = new List<char> { 'a', 'z', 'h', 'd', };
            letters.Swap<char>(1, 1);

            Assert.IsTrue(letters.IndexOf('z') == 1);
            Assert.IsTrue(letters.IndexOf('d') == 3);
        }

        [TestMethod]        
        public void If_I_Try_To_Swap_Two_Elements_Having_Other_Letters_In_Collection()
        {
            IList<char> letters = new List<char> { 'z', 'a', 'b', 'w', 'm', };
            letters.Swap<char>('a', 'm');
            //
            Assert.IsTrue(letters.IndexOf('a') == 4);
            Assert.IsTrue(letters.IndexOf('m') == 1);            
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void If_I_Try_To_Swap_One_Element_Nonexistent()
        {
            IList<char> letters = new List<char> { 'z', 'a', 'b', 'w', 'm', };
            letters.Swap<char>('g', 'a');            
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void If_I_Try_To_Swap_Both_Elements_Nonexistents()
        {
            IList<char> letters = new List<char> { 'z', 'a', 'b', 'w', 'm', };
            letters.Swap<char>('g', '2');            
        }       
    }
}