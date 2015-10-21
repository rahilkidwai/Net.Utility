using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk.Net.Utility.Tests
{
    /// <summary>
    /// This class contains unit tests.
    /// </summary>
    [TestClass()]
    public class DateTimeHelperTests
    {
        #region Initialization
        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void DateTimeHelperTestsInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void DateTimeHelperTestsCleanup()
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
        #region Test(s) for: TryParse(String, DateTime&)
        [TestMethod]
        public void DateHelper_TryParse_Parses_Date_In_Valid_Formats()
        {
            DateTime dt;

            Assert.AreEqual(true, DateTimeHelper.TryParse("20120101", out dt));

            Assert.AreEqual(2012, dt.Year);

            Assert.AreEqual(1, dt.Month);

            Assert.AreEqual(1, dt.Day);

            Assert.AreEqual(0, dt.Hour);

            Assert.AreEqual(0, dt.Minute);

            Assert.AreEqual(0, dt.Second);

            Assert.AreEqual(0, dt.Millisecond);

            Assert.AreEqual(true, DateTimeHelper.TryParse("20101112", "1234", out dt));

            Assert.AreEqual(2010, dt.Year);

            Assert.AreEqual(11, dt.Month);

            Assert.AreEqual(12, dt.Day);

            Assert.AreEqual(12, dt.Hour);

            Assert.AreEqual(34, dt.Minute);

            Assert.AreEqual(0, dt.Second);

            Assert.AreEqual(0, dt.Millisecond);

            Assert.AreEqual(true, DateTimeHelper.TryParse("20000103", null, out dt));

            Assert.AreEqual(2000, dt.Year);

            Assert.AreEqual(1, dt.Month);

            Assert.AreEqual(3, dt.Day);

            Assert.AreEqual(0, dt.Hour);

            Assert.AreEqual(0, dt.Minute);

            Assert.AreEqual(0, dt.Second);

            Assert.AreEqual(0, dt.Millisecond);

            Assert.AreEqual(true, DateTimeHelper.TryParse("20010302", " ", out dt));

            Assert.AreEqual(2001, dt.Year);

            Assert.AreEqual(3, dt.Month);

            Assert.AreEqual(2, dt.Day);

            Assert.AreEqual(0, dt.Hour);

            Assert.AreEqual(0, dt.Minute);

            Assert.AreEqual(0, dt.Second);

            Assert.AreEqual(0, dt.Millisecond);
        }

        #endregion Test(s) for: TryParse(String, DateTime&)

        #region Test(s) for: TryParse(String, String, DateTime&)
        #endregion Test(s) for: TryParse(String, String, DateTime&)

        #region Test(s) for: TryParseUtc(String, DateTime&)
        [TestMethod]
        public void TryParseUtc_Invalid_Value_Results_False()
        {
            DateTime date;

            Assert.AreEqual(DateTimeHelper.TryParseUtc(null, out date), false);

            Assert.AreEqual(DateTimeHelper.TryParseUtc(string.Empty, out date), false);

            Assert.AreEqual(DateTimeHelper.TryParseUtc("  ", out date), false);

            Assert.AreEqual(DateTimeHelper.TryParseUtc(" 123abc ", out date), false);
        }

        [TestMethod]
        public void TryParseUtc_Valid_Date_Results_True()
        {
            DateTime date;

            DateTime now = DateTime.Now;

            string nowUniversal = now.ToUniversalTime().ToString();

            Assert.AreEqual(DateTimeHelper.TryParseUtc("20-May-2011 15:20:00", out date), true);

            Assert.AreEqual(DateTimeHelper.TryParseUtc("2013-01-22 22:31:28.103", out date), true);

            Assert.AreEqual(DateTimeHelper.TryParseUtc("2013-01-22 22:31:28.103Z", out date), true);

            Assert.AreEqual(DateTimeHelper.TryParseUtc(nowUniversal, out date), true);

            Assert.AreEqual(date.Year, now.Year);

            Assert.AreEqual(date.Month, now.Month);

            Assert.AreEqual(date.Day, now.Day);

            Assert.AreEqual(date.Hour, now.Hour);

            Assert.AreEqual(date.Minute, now.Minute);

            Assert.AreEqual(date.Second, now.Second);
        }
        #endregion Test(s) for: TryParseUtc(String, String, DateTime&)

        #region Test(s) for: GetFormattedTime(String, Boolean)
        #endregion Test(s) for: GetFormattedTime(String, Boolean)
        #endregion Unit Tests
    }
}



