using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskApp.Repository;
using TaskApp.Service;


namespace TaskApp.Factory.Service
{
    public class ServiceFactory
    {
        private static DbContext context = new taskDomainDBEntities();
        private static IRepository<Task> taskRepository = new Repository<Task>(context);
        private static IRepository<User> userRepository = new Repository<User>(context);
        public ITaskService getTaskService()
        {
            return new TaskService(taskRepository);
        }
        public IUserService getUserService()
        {
            return new UserService(userRepository);
        }

    }
}