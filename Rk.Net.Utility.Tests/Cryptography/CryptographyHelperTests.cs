using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk.Net.Utility.Tests
{
    /// <summary>
    /// This class contains unit tests.
    /// </summary>
    [TestClass()]
    public class CryptographyHelperTests
    {
        #region Initialization
        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void CryptographyHelperTestsInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void CryptographyHelperTestsCleanup()
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
        #region Test(s) for: EncryptText(String, String, String)
        #endregion Test(s) for: EncryptText(String, String, String)

        #region Test(s) for: DecryptText(String, String, String)
        #endregion Test(s) for: DecryptText(String, String, String)

        #region Test(s) for: Base64StringToUTF8String(String)
        #endregion Test(s) for: Base64StringToUTF8String(String)

        #region Test(s) for: UTF8StringToBytes(String)
        #endregion Test(s) for: UTF8StringToBytes(String)

        #region Test(s) for: Base64StringToBytes(String)
        #endregion Test(s) for: Base64StringToBytes(String)

        #region Test(s) for: BytesToUTF8String(Byte[])
        #endregion Test(s) for: BytesToUTF8String(Byte[])

        #region Test(s) for: BytesToBase64String(Byte[])
        #endregion Test(s) for: BytesToBase64String(Byte[])

        #region Test(s) for: GetBase64Hash(String)
        #endregion Test(s) for: GetBase64Hash(String)

        #region Test(s) for: ROT13CipherText(String)
        #endregion Test(s) for: ROT13CipherText(String)

        #region Test(s) for: ROT13DecipherText(String)
        #endregion Test(s) for: ROT13DecipherText(String)
        #endregion Unit Tests
    }
}



