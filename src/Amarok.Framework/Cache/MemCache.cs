using System;
using System.Runtime.Caching;
using Amarok.Framework.Contracts;

namespace Amarok.Framework.Cache
{
    public class MemCache
    {
        public static ObjectCache Cache { get; private set; }
        private static CacheItemPolicy Policy { get; set; }
        private static readonly object SyncRoot = new object();

        static MemCache()
        {
            Cache = MemoryCache.Default;
            Policy = new CacheItemPolicy()
            {
                // One day expiration by default
                SlidingExpiration = new TimeSpan(24, 0, 0),
            };
        }

        public static bool Has(string key)
        {
            try
            {
                return Cache[key] != null;
            }
            catch
            {
                return false;
            }
        }

        public static T Get<T>(string key)
        {
            T retrievedItem = (T)Cache[key];
            Ensure.That(retrievedItem != null).IsTrue().Otherwise().Throw<ArgumentException>("Invalid key.");
            return retrievedItem;            
        }

        public static bool Add<T>(T item, string key)
        {
            return Add<T>(item, key, Policy.SlidingExpiration);
        }

        public static bool Add<T>(T item, string key, int hours = default(int), int minutes = default(int), int seconds = default(int))
        {
            hours = hours == 0 && minutes == 0 && seconds == 0 ? 1 : hours;
            //
            return Add<T>(item, key, new TimeSpan(hours, minutes, seconds));
        }

        public static bool Add<T>(T item, string key, TimeSpan expirationTime)
        {
            lock (SyncRoot)
            {
                if (item != null && !Has(key))
                {
                    Cache.Add(new CacheItem(key, item), new CacheItemPolicy()
                    {
                        SlidingExpiration = expirationTime
                    });
                    return true;
                }
                return false;
            }
        }
    }
}