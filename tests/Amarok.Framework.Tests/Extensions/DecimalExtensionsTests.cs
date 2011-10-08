using System;
using System.Globalization;
using System.Threading;
using Amarok.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Extensions
{
    /// <summary>
    /// Summary description for DecimalTest
    /// </summary>
    [TestClass]
    public class DecimalExtensionsTests
    {
        public DecimalExtensionsTests() { }

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
        public void If_I_Call_ToString_From_0_Decimal_And_One_Decimal_Place()
        {
            decimal input = 0.0M;
            string result = input.ToString(1);
            string expected = String.Format("0{0}0", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            //
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_0_Decimal_And_One_Decimal_Place_And_Specific_Culture()
        {
            decimal input = 0.0M;
            string result = input.ToString(1, new CultureInfo("pt-BR"));
            //
            Assert.AreEqual("0,0", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_0_Decimal_And_No_Decimal_Places()
        {
            decimal input = 0.0M;
            string result = input.ToString(0);
            //
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_0_Decimal_And_No_Decimal_Places_And_Specific_Culture()
        {
            decimal input = 0.0M;
            string result = input.ToString(0, new CultureInfo("pt-BR"));
            //
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_With_2_Decimal_Cases()
        {
            decimal input = 80.7946M;
            string result = input.ToString(2);
            string expected = String.Format("80{0}79", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            //
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_With_2_Decimal_Cases_And_Specific_Culture()
        {
            decimal input = 49.1234M;
            string result = input.ToString(2, new CultureInfo("pt-BR"));
            //
            Assert.AreEqual("49,12", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_With_3_Decimal_Cases()
        {
            decimal input = 120.88750M;
            string result = input.ToString(3);
            string expected = String.Format("120{0}887", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            //
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_With_3_Decimal_Cases_And_Specific_Culture()
        {
            decimal input = 120.88750M;
            string result = input.ToString(3, new CultureInfo("pt-BR"));
            //
            Assert.AreEqual("120,887", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_Without_Decimal_Cases()
        {
            decimal input = 120M;
            string result = input.ToString(3);
            //
            Assert.AreEqual("120", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_A_Decimal_Without_Decimal_Cases_And_Specific_Culture()
        {
            decimal input = 120M;
            string result = input.ToString(3, new CultureInfo("pt-BR"));
            //
            Assert.AreEqual("120", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_Negative_Decimal_And_One_Decimal_Place()
        {
            decimal input = -10.1M;
            string result = input.ToString(1);
            string expected = String.Format("-10{0}1", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            //
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_Negative_Decimal_And_Without_Decimal_Places()
        {
            decimal input = -10.1M;
            string result = input.ToString(0);
            //
            Assert.AreEqual("-10", result);
        }

        [TestMethod]
        public void If_I_Call_ToString_From_Negative_Decimal_And_Specific_Culture()
        {
            decimal input = -23.1M;
            string result = input.ToString(0, new CultureInfo("pt-BR"));
            //
            Assert.AreEqual("-23", result);            
        }
    }
}