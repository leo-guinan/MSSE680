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
            Boolean addEntity(T entity);
            Boolean delete(T entity);
            T getEntity(object id);
            Boolean updateEntity(T entity);                
            IQueryable<T> getAllEntities();
            List<T> getAllEntitiesAsList();
    }
    
}
