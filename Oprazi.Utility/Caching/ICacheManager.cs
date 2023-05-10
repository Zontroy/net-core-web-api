using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Utility.Caching
{
    public interface ICacheManager
    {

        T Get<T>(string key);
        void Add<T>(T o, string key, MemoryCacheEntryOptions memoryCacheEntryOptions);
        void Remove(string key);
    }
}
