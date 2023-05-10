﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Oprazi.Utility.Caching
{
    public interface ICacheKeyService
    {
        string GenerateCacheKey(string cacheName, params object[] args);
    }
}
