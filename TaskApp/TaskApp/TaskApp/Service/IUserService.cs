using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskApp.Service
{
    public interface IUserService
    {
        Boolean addUser(User user);
        Boolean modifyUser(User user);
        User getUserById(int id);
        IList<User> getAllUsers();
        Boolean removeUser(User user);
    }
}