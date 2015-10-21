using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk.Net.Utility.Tests
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void Cache_Initial_Count_Should_Be_0()
        {
            Cache<string, int> cache = new Cache<string, int>();
            int EXPECTED = 0;
            Assert.AreEqual(EXPECTED, cache.Count);
        }

        [TestMethod]
        public void Cache_Initial_Flush_Count_Should_Be_0()
        {
            Cache<string, int> cache = new Cache<string, int>();
            int EXPECTED = 0;
            Assert.AreEqual(EXPECTED, cache.Flush());
        }

        [TestMethod]
        public void Cache_Initial_Contains_Should_Return_False()
        {
            Cache<string, int> cache = new Cache<string, int>();
            bool EXPECTED = false;
            Assert.AreEqual(EXPECTED, cache.Contains(string.Empty));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cache_Add_Null_Key_Should_Throw_Exception()
        {
            Cache<string, int> cache = new Cache<string, int>();
            cache.Add(null, 0);
        }

        [TestMethod]
        public void Cache_Add_Item_Key_Should_Return_True()
        {
            Cache<string, int> cache = new Cache<string, int>();
            bool EXPECTED = true;
            Assert.AreEqual(EXPECTED, cache.Add("1", 1));
        }

        [TestMethod]
        public void Cache_Get_Item_Key_Should_Return_Item()
        {
            Cache<string, int> cache = new Cache<string, int>();
            int EXPECTED = 1;
            cache.Add("1", 1);
            Assert.AreEqual(EXPECTED, cache.Get("1"));
        }

        [TestMethod]
        public void Cache_Remove_Item_Key_Should_Remove_Item()
        {
            Cache<string, int> cache = new Cache<string, int>();
            bool EXPECTED = true;
            cache.Add("1", 1);
            Assert.AreEqual(EXPECTED, cache.Remove("1"));
            int EXPECTEDCOUNT = 0;
            Assert.AreEqual(EXPECTEDCOUNT, cache.Count);
            EXPECTED = false;
            Assert.AreEqual(EXPECTED, cache.Contains("1"));
        }

    }
}



