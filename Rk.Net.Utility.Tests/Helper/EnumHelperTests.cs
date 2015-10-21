using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk.Net.Utility.Tests
{
    /// <summary>
    /// This class contains unit tests.
    /// </summary>
    [TestClass()]
    public class EnumHelperTests
    {
        #region Initialization
        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void EnumHelperTestsInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void EnumHelperTestsCleanup()
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
        #region Test(s) for: GetDescription(Enum)
        [TestMethod]
        public void GetDescription_Returns_Enumerator_Description()
        {
            Assert.AreEqual("Mock Enumerator 1", EnumHelper.GetDescription(MockEnum.MockEnumerator1), false);

            Assert.AreEqual("MockEnumerator2", EnumHelper.GetDescription(MockEnum.MockEnumerator2), false);
        }
        #endregion Test(s) for: GetDescription(Enum)

        #region Test(s) for: GetList(Type)
        [TestMethod]
        public void GetList_Returns_Enumerators()
        {
            IList<KeyValuePair<int, string>> enums = EnumHelper.GetList(typeof(MockEnum));

            Assert.AreEqual(2, enums.Count);

            Assert.AreEqual("Mock Enumerator 1", enums[0].Value, false);

            Assert.AreEqual("MockEnumerator2", enums[1].Value, false);

            Assert.AreEqual(1, enums[0].Key);

            Assert.AreEqual(2, enums[1].Key);
        }
        #endregion Test(s) for: GetList(Type)
        #endregion Unit Tests

        #region MockEnum
        enum MockEnum
        {
            [System.ComponentModel.Description("Mock Enumerator 1")]
            MockEnumerator1 = 1,            
            MockEnumerator2 = 2
        }
        #endregion
    }
}



