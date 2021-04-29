using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly List<T> entities = new List<T>();

        public void Add(T entity)
        {
            this.entities.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities;
        }
    }
}
