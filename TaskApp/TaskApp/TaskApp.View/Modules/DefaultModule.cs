using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Business;
using TaskApp.Factory.Service;
using TaskApp.Service;
using TaskApp.View.Session;

namespace TaskApp.View.Modules
{
    public class DefaultModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserManager>().To<UserManager>().InSingletonScope();
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IServiceFactory>().To<ServiceFactory>().InSingletonScope();
            Bind<ISession>().To<CurrentSession>().InSingletonScope();
            Bind<ITaskManager>().To<TaskManager>().InSingletonScope();
            Bind<ITaskService>().To<TaskService>().InSingletonScope();

        }
    }
}