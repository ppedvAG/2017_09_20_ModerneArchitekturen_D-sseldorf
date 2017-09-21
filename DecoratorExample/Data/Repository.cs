using System.Collections.Generic;
using DecoratorExample.Core;

namespace DecoratorExample.Data
{
    public class Repository : IRepository
    {
        public string Get(int id) => "Stanislaus";

        public IEnumerable<string> GetAllCustomers() => new[]
            {
                "Luise",
                "Hannes",
                "Andrea"
            };
    }
}
