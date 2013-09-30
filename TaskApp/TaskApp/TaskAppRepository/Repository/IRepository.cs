using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace TaskApp.Repository
{
   public interface IRepository<T> 
          where T : class   
    {                   
            T addEntity(T entity);
            Boolean delete(T entity);
            T getEntity(object id);
            T updateEntity(T entity);                
            IQueryable<T> getAllEntities();
            List<T> getAllEntitiesAsList();
    }
    
}
