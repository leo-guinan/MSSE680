using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using TaskApp.Business;
using TaskApp.Domain;
using TaskApp.Factory.Service;
using TaskApp.Service;

namespace TaskApp.Tests.Business
{
    [TestClass]
    public class TaskManagerTest
    {

        private static readonly String name = "name";
        private static readonly String notes = "notes";
        private static readonly String description = "description";
        private static readonly int priority = 5;
        private static readonly DateTime dateCreated = new DateTime(2013, 1, 1);
        private static readonly DateTime dueDate = new DateTime(2014, 1, 1);
        private static readonly int estimateTime = 2;
        private static readonly String estimateType = "hours";

        private static readonly String username = "username";
        private static readonly String password = "password";


        MockFactory mockFactory;
        Mock<IServiceFactory> serviceFactoryMock;
        Mock<IUserService> userServiceMock;
        Mock<ITaskService> taskServiceMock;
        
        ITaskManager taskManager;
        Task task;
        User user;
        [TestInitialize]
        public void setup()
        {
            user = new User();
            user.username = username;
            user.password = password;

            task = new Task();
            task.name = name;
            task.description = description;
            task.notes = notes;
            task.priority = priority;
            task.dueDate = dueDate;
            task.dateCreated = dateCreated;
            Estimate estimate = new Estimate();
            estimate.type = estimateType;
            estimate.time = estimateTime;
            task.Estimates.Add(estimate);
            mockFactory = new MockFactory();
            serviceFactoryMock = mockFactory.CreateMock<IServiceFactory>();
            userServiceMock = mockFactory.CreateMock<IUserService>();
            taskServiceMock = mockFactory.CreateMock<ITaskService>();
            serviceFactoryMock.Expects.One.MethodWith(f => f.getService("userService")).WillReturn((IService)userServiceMock.MockObject);
            serviceFactoryMock.Expects.One.MethodWith(f => f.getService("taskService")).WillReturn((IService)taskServiceMock.MockObject);
            taskManager = new TaskManager(serviceFactoryMock.MockObject);


            
        }






        [TestMethod]
        public void TestAddTask()
        {
            taskServiceMock.Expects.One.Method(s => s.addTask(task)).WithAnyArguments().WillReturn(true);
            Assert.IsTrue(taskManager.addTask(name, notes, description, dateCreated, dueDate, priority, estimateTime, estimateType));   
        }

        [TestMethod]
        public void TestModifyTask()
        {
            int id = 1;
            taskServiceMock.Expects.One.Method(s => s.modifyTask(task)).WithAnyArguments().WillReturn(true);
            taskServiceMock.Expects.One.Method(s => s.getTaskById(id)).WithAnyArguments().WillReturn(task);

            Assert.IsTrue(taskManager.modifyTask(name, notes, description, dateCreated, dueDate, priority, estimateTime, estimateType, 1));  

        }

        [TestMethod]
        public void TestLogin()
        {
            userServiceMock.Expects.One.Method(s => s.authenticateUser(user)).WithAnyArguments().WillReturn(true);
            Assert.IsTrue(taskManager.login(username, password));
        }
    }
}
