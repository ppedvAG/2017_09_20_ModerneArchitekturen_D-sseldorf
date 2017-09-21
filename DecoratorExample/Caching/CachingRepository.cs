using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Caching
{
    public class CachingRepository : IRepository
    {
        private readonly IRepository _baseRepository;
        private readonly ICache _cache;
        private readonly int _cachtime;

        private DateTime _lastLoadedTime;

        /// <param name="cachtime">The cachtime in seconds.</param>
        public CachingRepository(IRepository baseRepository, ICache cache, int cachtime = 30)
        {
            _baseRepository = baseRepository;
            _cache = cache;
            _cachtime = cachtime;
        }

        public IEnumerable<string> GetAllCustomers()
        {
            const string cacheKey = "CachingRepository_GetAllCustomers";

            if (!_cache.Contains(cacheKey) || ShouldRelaodData())
            {
                _cache.Add(cacheKey,_baseRepository.GetAllCustomers());
                _lastLoadedTime = DateTime.Now;
            }

            return _cache.Get<IEnumerable<string>>(cacheKey);
        }

        private bool ShouldRelaodData() => (DateTime.Now - _lastLoadedTime).TotalSeconds > _cachtime;
    }
}
