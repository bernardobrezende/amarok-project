using System;
using Amarok.Framework.Cache;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Cache
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void If_I_Try_To_Add_An_Item_To_Cache_It_Must_Returns_True()
        {
            string itemInCache = "The quick brown fox jumps over the lazy dog";
            string key = "MS'_favorite_pangram";
            //            
            ICache cache = new MemCache();
            bool result = cache.Add<string>(itemInCache, key);
            //
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Add_A_Null_Item_To_Cache_It_Must_Throws_Exception()
        {
            string key = "justanotherkey";
            //            
            ICache cache = new MemCache();
            cache.Add<string>(null, key);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Add_An_Item_With_Null_Key_It_Must_Throws_Exception()
        {
            string itemInCache = "The quick brown fox jumps over the lazy dog";
            //            
            ICache cache = new MemCache();
            cache.Add<string>(itemInCache, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void If_I_Try_To_Add_Null_Key_Value_Pair_It_Must_Throws_Exception()
        {
            ICache cache = new MemCache();
            cache.Add<string>(null, null);
        }

        [TestMethod]        
        public void If_I_Try_To_Add_An_Existent_Item_It_Must_Returns_False()
        {
            string itemInCache = "The quick brown fox jumps over the lazy dog";
            string anotherItem = "justanotheritem";
            string key = "MS'_favorite_pangram";
            ICache cache = new MemCache();
            //            
            bool firstAddition = cache.Add<string>(itemInCache, key);
            bool secondAddition = cache.Add<string>(anotherItem, key);
            //            
            Assert.IsFalse(secondAddition);
        }
    }
}