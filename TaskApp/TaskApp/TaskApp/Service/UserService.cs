using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskApp.Repository;

namespace TaskApp.Service
{
    public class UserService : IUserService
    {
        IRepository<User> repository;
        
        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }


        Boolean addUser(User user)
        {
            return repository.addEntity(user);
        }

        Boolean modifyUser(User user)
        {
            return repository.updateEntity(user);
        }

        User getUserById(int id)
        {
            return repository.getEntity(id);

        }

        IList<User> getAllUsers()
        {
            IList<User> allUsers = new List<User>();

            foreach (IQueryable item in repository.getAllEntities())
            {
                allUsers.Add((User)item);
            }

            return allUsers;

        }

        Boolean removeUser(User user)
        {
            return repository.delete(user);
        }
    }
}