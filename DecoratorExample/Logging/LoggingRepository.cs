using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Logging
{
    internal class LoggingRepository : IRepository
    {
        private readonly IRepository _baseRepository;
        private readonly ILogger _logger;

        public LoggingRepository(IRepository baseRepository, ILogger logger)
        {
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public IEnumerable<string> GetAllCustomers()
        {
            _logger.Log($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Customers werden geladen.");

            var result = _baseRepository.GetAllCustomers();
            
            _logger.Log($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Customers wurden fertig geladen.");

            return result;
        }
    }
}
