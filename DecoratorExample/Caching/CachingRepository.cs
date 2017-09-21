using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Caching
{
    public class CachingRepository : RepositoryDecorator
    {
        private readonly ICache _cache;
        private readonly int _cachtime;

        private DateTime _lastLoadedTime;

        /// <param name="cachtime">The cachtime in seconds.</param>
        public CachingRepository(IRepository baseRepository, ICache cache, int cachtime = 30)
            : base(baseRepository)
        {
            _cache = cache;
            _cachtime = cachtime;
        }

        public override IEnumerable<string> GetAllCustomers()
        {
            const string cacheKey = "CachingRepository_GetAllCustomers";

            if (!_cache.Contains(cacheKey) || ShouldRelaodData())
            {
                _cache.Add(cacheKey, base.GetAllCustomers());
                _lastLoadedTime = DateTime.Now;
            }

            return _cache.Get<IEnumerable<string>>(cacheKey);
        }

        private bool ShouldRelaodData() => (DateTime.Now - _lastLoadedTime).TotalSeconds > _cachtime;
    }
}
