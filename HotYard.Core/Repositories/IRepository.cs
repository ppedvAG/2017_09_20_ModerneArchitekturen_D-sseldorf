using HotYard.Core.Models;
using System.Collections.Generic;

namespace HotYard.Core.Repositories
{
    public interface IRepository<TEnity> where TEnity : Entity
    {
        TEnity Get(int id);
        IEnumerable<TEnity> GetAll();
    }
}
