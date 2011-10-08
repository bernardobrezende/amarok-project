using System;
using System.Collections.Generic;

namespace Amarok.Framework.Cache
{
    public interface ICache
    {
        bool Has(string key);
        T Get<T>(string key);
        bool Add<T>(T item, string key);
        bool Add<T>(KeyValuePair<string, T> keyValuePair);
        bool Add<T>(T item, string key, int hours = default(int), int minutes = default(int), int seconds = default(int));
        bool Add<T>(T item, string key, TimeSpan expirationTime);
        bool Remove(string key);
    }
}
