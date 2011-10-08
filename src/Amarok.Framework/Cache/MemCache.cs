using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Amarok.Framework.Contracts;

namespace Amarok.Framework.Cache
{
    public class MemCache : ICache
    {
        private static IList<string> CurrentKeys;
        private static ObjectCache Cache { get; set; }
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
            CurrentKeys = new List<string>();
        }

        public bool Has(string key)
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

        public T Get<T>(string key)
        {
            T retrievedItem = (T)Cache[key];
            Ensure.That(retrievedItem != null).IsTrue().Otherwise.Throw<ArgumentException>("Invalid key.");
            return retrievedItem;
        }

        public bool Add<T>(KeyValuePair<string, T> keyValuePair)
        {
            return Add<T>(keyValuePair.Value, keyValuePair.Key);
        }

        public bool Add<T>(T item, string key)
        {
            return Add<T>(item, key, Policy.SlidingExpiration);
        }

        public bool Add<T>(T item, string key, int hours = default(int), int minutes = default(int), int seconds = default(int))
        {
            hours = hours == 0 && minutes == 0 && seconds == 0 ? 1 : hours;
            //
            return Add<T>(item, key, new TimeSpan(hours, minutes, seconds));
        }

        public bool Add<T>(T item, string key, TimeSpan expirationTime)
        {
            Ensure.That(item != null && !String.IsNullOrEmpty(key))
                .IsTrue()
                .Otherwise
                .Throw<ArgumentException>("Unable to add the informed key-value pair to the cache.");
            //            
            lock (SyncRoot)
            {
                if (!Has(key))
                {
                    Cache.Add(new CacheItem(key, item), new CacheItemPolicy()
                    {
                        SlidingExpiration = expirationTime
                    });
                    CurrentKeys.Add(key);
                    return true;
                }
                return false;
            }
        }

        public bool Remove(string key)
        {
            try
            {
                lock (SyncRoot)
                    Cache.Remove(key);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Clear()
        {
            foreach (string key in CurrentKeys)
            {
                lock (SyncRoot)
                    Cache.Remove(key);
            }
        }

        ~MemCache()
        {
            this.Clear();
        }
    }
}