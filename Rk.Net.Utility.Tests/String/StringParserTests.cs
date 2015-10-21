using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk.Net.Utility.Tests
{
    /// <summary>
    /// This class contains unit tests.
    /// </summary>
    [TestClass()]
    public class StringParserTests
    {
        #region Initialization
        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void StringParserTestsInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void StringParserTestsCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }
        #endregion Initialization

        #region Unit Tests
        #region Test(s) for: Item
        [TestMethod()]
        public void Item_Returns_Token_At_Given_Index()
        {
            StringParser target = new StringParser("unit test", ' ', StringSplitOptions.RemoveEmptyEntries);

            string EXPECTED = "unit"; 
            Assert.AreEqual(EXPECTED, target[0], false);

            EXPECTED = "test";
            Assert.AreEqual(EXPECTED, target[1], false);
            
            target = new StringParser(" unit  test ", " ", StringSplitOptions.RemoveEmptyEntries);
            
            EXPECTED = "unit";
            Assert.AreEqual(EXPECTED, target[0], false);

            EXPECTED = "test";
            Assert.AreEqual(EXPECTED, target[1], false);
        }
        #endregion Test(s) for: Item

        #region Test(s) for: Count
        [TestMethod()]
        public void Count_Returns_Number_Of_Tokens()
        {
            Int32 EXPECTED = 2;
            StringParser target = new StringParser("unit test", ' ', StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(EXPECTED, target.Count);

            target = new StringParser(" unit  test ", " ", StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(EXPECTED, target.Count);
        }
        #endregion Test(s) for: Count

        #region Test(s) for: GetEnumerator()
        [TestMethod()]
        public void GetEnumerator_Enumerates_Tokens()
        {
            Int32 EXPECTED_COUNT = 2;

            string EXPECTED = null;

            StringParser target = new StringParser("unit test", ' ', StringSplitOptions.RemoveEmptyEntries);

            Int32 ACTUAL_COUNT = 0;

            foreach (string token in target)
            {
                ++ACTUAL_COUNT;

                if (ACTUAL_COUNT == 1) EXPECTED = "unit";
                else if (ACTUAL_COUNT == 2) EXPECTED = "test";
                else EXPECTED = "";

                Assert.AreEqual(EXPECTED, token);
            }

            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT);
        }
        #endregion Test(s) for: GetEnumerator()
        #endregion Unit Tests
    }
}



