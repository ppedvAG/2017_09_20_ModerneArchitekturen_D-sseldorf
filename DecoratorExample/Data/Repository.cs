using System.Collections.Generic;
using DecoratorExample.Core;

namespace DecoratorExample.Data
{
    public class Repository : IRepository
    {
        public IEnumerable<string> GetAllCustomers()
        {
            // der Datenbank zugriff
            return new[]
            {
                "Luise",
                "Hannes",
                "Andrea"
            };
        }
    }
}
