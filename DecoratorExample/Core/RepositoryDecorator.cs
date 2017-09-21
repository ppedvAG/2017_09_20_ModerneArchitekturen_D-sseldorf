using System.Collections.Generic;

namespace DecoratorExample.Core
{
    public abstract class RepositoryDecorator : IRepository
    {
        protected IRepository BaseRepository { get; }

        public RepositoryDecorator(IRepository baseRepository) => BaseRepository = baseRepository;

        public virtual string Get(int id) => BaseRepository.Get(id);
        public virtual IEnumerable<string> GetAllCustomers() => BaseRepository.GetAllCustomers();
    }
}
