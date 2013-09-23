using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace TaskApp.Repository
{
    public class Repository<T> : IRepository<T>
          where T : class
    {

        
    public Repository(DbContext context)
    {
        this.context = context;

    }

        private DbContext context;
        private IDbSet<T> entities
        {
            get
            {
                return context.Set<T>();
            }
        }

        public Boolean addEntity(T entity)
        {
            if (entities.Add(entity) != null)
            {
                this.context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean delete(T entity)
        {
            if (entities.Remove(entity) != null) 
            {
                this.context.SaveChanges();
                return true;
            }
            return false;
        }   

        public T getEntity(object id)
        {
            return entities.Find(id);
        }

        public Boolean updateEntity(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            this.context.SaveChanges();
            return true;
        }

        public IQueryable<T> getAllEntities()
        {
            return entities.AsQueryable();
            
        }

        public List<T> getAllEntitiesAsList()
        {
            return entities.ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                    this.context = null;
                }
            }
        }
        
           
    }
}