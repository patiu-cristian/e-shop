using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class InMemoryRepository<T> : IRepository<T> where T : IIdentifiable
    {
        private readonly List<T> entities = new List<T>();

        public int lastId = 0;

        public void Add(T entity)
        {
            entity.Id = ++this.lastId;
            this.entities.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities;
        }

        public T GetById(int id)
        {
            foreach (var entity in this.entities)
            {
                if (entity.Id == id)
                {
                    return entity;
                }
            }
            
            throw new Exception("Entity not found!");       
        }

        public void Remove(int id)
        {
            foreach(var entity in this.entities) 
            {
                if (entity.Id == id)
                {
                    entities.Remove(entity);
                    return;
                }
            }
        }

        public void Update(T updateEntity, int id)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                T entity = this.entities[i];

                if (entity.Id == id)
                {
                    this.entities[i] = updateEntity;

                    return;
                }
            }
        }
    }
}
