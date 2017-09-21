using System.Collections.Generic;

namespace DecoratorExample.Core
{
    public interface IRepository
    {
        string Get(int id);
        IEnumerable<string> GetAllCustomers();
    }
}
