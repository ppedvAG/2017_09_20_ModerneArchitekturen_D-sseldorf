using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Logging
{
    internal class LoggingRepository : RepositoryDecorator
    {
        private readonly ILogger _logger;

        public LoggingRepository(IRepository baseRepository, ILogger logger)
            : base(baseRepository) => _logger = logger;
        
        public override IEnumerable<string> GetAllCustomers()
        {
            _logger.Log($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Customers werden geladen.");

            var result = base.GetAllCustomers();
            
            _logger.Log($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Customers wurden fertig geladen.");

            return result;
        }
    }
}
