using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk.Net.Utility.Tests
{
	/// <summary>
	/// This class contains unit tests.
	/// </summary>
	[TestClass()]
	public class StringHelperTests
	{
		#region Initialization
		/// <summary>
		/// Gets or sets the test context which provides information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext{ get; set; }

		// Use ClassInitialize to run code before running the first test in the class
		[ClassInitialize()]
		public static void StringHelperTestsInitialize(TestContext testContext)
		{
		}

		// Use ClassCleanup to run code after all tests in a class have run
		[ClassCleanup()]
		public static void StringHelperTestsCleanup()
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
		#endregion

		#region Unit Tests
		#region Test(s) for: NumberToWords(Int32)
		[TestMethod]
		public void NumberToWords_0_Results_Zero()
		{
			Assert.AreEqual("Zero", StringHelper.NumberToWords(0), false);
		}

		[TestMethod]
		public void NumberToWords_1_Results_One()
		{
			Assert.AreEqual("One", StringHelper.NumberToWords(1), false);
		}

		[TestMethod]
		public void NumberToWords_2_Results_Two()
		{
			Assert.AreEqual("Two", StringHelper.NumberToWords(2), false);
		}

		[TestMethod]
		public void NumberToWords_3_Results_Three()
		{
			Assert.AreEqual("Three", StringHelper.NumberToWords(3), false);
		}

		[TestMethod]
		public void NumberToWords_4_Results_Four()
		{
			Assert.AreEqual("Four", StringHelper.NumberToWords(4), false);
		}

		[TestMethod]
		public void NumberToWords_5_Results_Five()
		{
			Assert.AreEqual("Five", StringHelper.NumberToWords(5), false);
		}

		[TestMethod]
		public void NumberToWords_6_Results_Six()
		{
			Assert.AreEqual("Six", StringHelper.NumberToWords(6), false);
		}

		[TestMethod]
		public void NumberToWords_7_Results_Seven()
		{
			Assert.AreEqual("Seven", StringHelper.NumberToWords(7), false);
		}

		[TestMethod]
		public void NumberToWords_8_Results_Eight()
		{
			Assert.AreEqual("Eight", StringHelper.NumberToWords(8), false);
		}

		[TestMethod]
		public void NumberToWords_9_Results_Nine()
		{
			Assert.AreEqual("Nine", StringHelper.NumberToWords(9), false);
		}

		[TestMethod]
		public void NumberToWords_10_Results_Ten()
		{
			Assert.AreEqual("Ten", StringHelper.NumberToWords(10), false);
		}

		[TestMethod]
		public void NumberToWords_11_Results_Eleven()
		{
			Assert.AreEqual("Eleven", StringHelper.NumberToWords(11), false);
		}

		[TestMethod]
		public void NumberToWords_12_Results_Twelve()
		{
			Assert.AreEqual("Twelve", StringHelper.NumberToWords(12), false);
		}

		[TestMethod]
		public void NumberToWords_13_Results_Thirteen()
		{
			Assert.AreEqual("Thirteen", StringHelper.NumberToWords(13), false);
		}

		[TestMethod]
		public void NumberToWords_14_Results_Fourteen()
		{
			Assert.AreEqual("Fourteen", StringHelper.NumberToWords(14), false);
		}

		[TestMethod]
		public void NumberToWords_15_Results_Fifteen()
		{
			Assert.AreEqual("Fifteen", StringHelper.NumberToWords(15), false);
		}

		[TestMethod]
		public void NumberToWords_16_Results_Sixteen()
		{
			Assert.AreEqual("Sixteen", StringHelper.NumberToWords(16), false);
		}

		[TestMethod]
		public void NumberToWords_17_Results_Seventeen()
		{
			Assert.AreEqual("Seventeen", StringHelper.NumberToWords(17), false);
		}

		[TestMethod]
		public void NumberToWords_18_Results_Eighteen()
		{
			Assert.AreEqual("Eighteen", StringHelper.NumberToWords(18), false);
		}

		[TestMethod]
		public void NumberToWords_19_Results_Nineteen()
		{
			Assert.AreEqual("Nineteen", StringHelper.NumberToWords(19), false);
		}

		[TestMethod]
		public void NumberToWords_20_Results_Twenty()
		{
			Assert.AreEqual("Twenty", StringHelper.NumberToWords(20), false);
		}

		[TestMethod]
		public void NumberToWords_30_Results_Thirty()
		{
			Assert.AreEqual("Thirty", StringHelper.NumberToWords(30), false);
		}

		[TestMethod]
		public void NumberToWords_40_Results_Forty()
		{
			Assert.AreEqual("Forty", StringHelper.NumberToWords(40), false);
		}

		[TestMethod]
		public void NumberToWords_50_Results_Fifty()
		{
			Assert.AreEqual("Fifty", StringHelper.NumberToWords(50), false);
		}

		[TestMethod]
		public void NumberToWords_60_Results_Sixty()
		{
			Assert.AreEqual("Sixty", StringHelper.NumberToWords(60), false);
		}

		[TestMethod]
		public void NumberToWords_70_Results_Seventy()
		{
			Assert.AreEqual("Seventy", StringHelper.NumberToWords(70), false);
		}

		[TestMethod]
		public void NumberToWords_80_Results_Eighty()
		{
			Assert.AreEqual("Eighty", StringHelper.NumberToWords(80), false);
		}

		[TestMethod]
		public void NumberToWords_90_Results_Ninety()
		{
			Assert.AreEqual("Ninety", StringHelper.NumberToWords(90), false);
		}

		[TestMethod]
		public void NumberToWords_100_Results_One_Hundred()
		{
			Assert.AreEqual("One Hundred", StringHelper.NumberToWords(100), false);
		}

		[TestMethod]
		public void NumberToWords_1234_Results_One_Thousand_Two_Hundred_And_Thirty_Four()
		{
			Assert.AreEqual("One Thousand Two Hundred And Thirty Four", StringHelper.NumberToWords(1234), false);
		}

		[TestMethod]
		public void NumberToWords_1000050_Results_One_Million_And_Fifty()
		{
			Assert.AreEqual("One Million And Fifty", StringHelper.NumberToWords(1000050), false);
		}

		[TestMethod]
		public void NumberToWords_Negative_167890_Results_Minus_One_Hundred_Sixty_Seven_Thousand_Eight_Hundred_And_Ninety()
		{
			Assert.AreEqual("Minus One Hundred And Sixty Seven Thousand Eight Hundred And Ninety", StringHelper.NumberToWords(-167890), false);
		}
		#endregion Test(s) for: NumberToWords(Int32)
		#endregion Unit Tests
	}
}



