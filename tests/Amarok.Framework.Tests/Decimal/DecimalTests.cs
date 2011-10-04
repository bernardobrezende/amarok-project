using Amarok.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Decimal
{
    /// <summary>
    /// Summary description for DecimalTest
    /// </summary>
    [TestClass]
    public class DecimalTests
    {
        public DecimalTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_With_2_Decimal_Cases()
        {
            decimal input = 80.7946M;
            string result = input.ToString(2);
            //
            Assert.AreEqual("80.79", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_With_2_Decimal_Cases_And_Specific_Culture()
        {
            decimal input = 49.1234M;
            string result = input.ToString(2, new System.Globalization.CultureInfo("pt-BR"));
            //
            Assert.AreEqual("49,12", result);
        }
    }
}
