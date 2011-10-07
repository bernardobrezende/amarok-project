using Amarok.Framework.Cache;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amarok.Framework.Tests.Cache
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void If_I_Try_To_Add_An_Item_To_Cache_It_Must_Returns_Me_True()
        {
            string itemInCache = "The quick brown fox jumps over the lazy dog";
            string key = "MS'_favorite_pangram";
            //            
            ICache cache = new MemCache();
            bool result = cache.Add<string>(itemInCache, key);
            //
            Assert.IsTrue(result);
        }
    }
}