using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Utility.Caching
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;

        public CacheManager(IMemoryCache cache)

        {
            _cache = cache;
        }
        public void Add<T>(T o, string key, MemoryCacheEntryOptions memoryCacheEntryOptions)
        {
            T cacheEntry;
       
            // Look for cache key.
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = o;

                // Set cache options.
                var cacheEntryOptions = memoryCacheEntryOptions;

                // Save data in cache.
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
        }

        public T Get<T>(string key)
        {

            return _cache.TryGetValue(key, out T result) ? result : default(T);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

    }
}
