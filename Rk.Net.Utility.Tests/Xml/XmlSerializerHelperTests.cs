using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk.Net.Utility.Tests
{
    /// <summary>
    /// This class contains unit tests.
    /// </summary>
    [TestClass()]
    public class XmlSerializerHelperTests
    {
        #region Initialization
        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void XmlSerializerHelperTestsInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void XmlSerializerHelperTestsCleanup()
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
        #region Test(s) for: Serialize(T) & Deserialize(T)
        //[TestMethod()]
        //public void Deserialized_Xml_Returns_Object_Equal_To_Serailized_Xml_Object()
        //{
        //    XmlSerializerMock mock1 = new XmlSerializerMock() { XmlDouble = 23.0, XmlInt = 13, XmlString = "mock" };

        //    string xml = XmlSerializerHelper.Serialize<XmlSerializerMock>(mock1);

        //    XmlSerializerMock mock2 = XmlSerializerHelper.Deserialize<XmlSerializerMock>(xml);

        //    Assert.AreEqual(mock1, mock2);
        //}
        #endregion Test(s) for: Serialize(T) & Deserialize(T)
        #endregion Unit Tests

        #region XmlSerializerMock
        [DataContract]
        class XmlSerializerMock
        {
            [DataMember]
            public int XmlInt { get; set; }
            [DataMember]
            public string XmlString { get; set; }
            [DataMember]
            public double XmlDouble { get; set; }
            public override bool Equals(object obj)
            {
                XmlSerializerMock mock = obj as XmlSerializerMock;

                if (mock == null) return false;

                if (this.XmlInt != mock.XmlInt) return false;

                if (this.XmlDouble != mock.XmlDouble) return false;

                return string.Equals(this.XmlString, mock.XmlString, System.StringComparison.CurrentCulture);
            }
            public override int GetHashCode()
            {
                return string.Format("{0}{1}{2}", XmlString == null ? string.Empty : XmlString, XmlInt, XmlString).GetHashCode();
            }
        }
        #endregion
    }
}



