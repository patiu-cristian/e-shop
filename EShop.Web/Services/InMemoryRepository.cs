using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        List<T> Memory = new List<T>();
        public void Add(T entity)
        {
            Memory.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Memory;
        }
    }
}
