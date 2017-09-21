using System.Collections.Generic;

namespace DecoratorExample.Core
{
    public interface IRepository
    {
        IEnumerable<string> GetAllCustomers();
    }
}
