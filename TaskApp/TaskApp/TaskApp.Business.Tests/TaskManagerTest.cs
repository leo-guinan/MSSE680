using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using TaskApp.Business;
using TaskApp.Domain;
using TaskApp.Factory.Service;
using TaskApp.Service;
using System.Collections.Generic;

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
        MockFactory mockFactory;
        Mock<IServiceFactory> serviceFactoryMock;
        Mock<IUserService> userServiceMock;
        Mock<ITaskService> taskServiceMock;
        ITaskManager taskManager;
        Task task;


        [TestInitialize]
        public void setup()
        {

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
        public void testGetAllTasksBy()
        {
            List<Task> tasks = new List<Task>();
            String priority = "priority";
            String dueDate = "dueDate";
            String dateCreated = "dateCreated";
            String badSort = "badSort";
            taskServiceMock.Expects.One.MethodWith(s => s.getAllTasksByPriority()).WillReturn(tasks);
            taskManager.getAllTasks(priority);
            taskServiceMock.Expects.One.MethodWith(s => s.getAllTasksByDueDate()).WillReturn(tasks);
            taskManager.getAllTasks(dueDate);
            taskServiceMock.Expects.One.MethodWith(s => s.getAllTasksByDateCreated()).WillReturn(tasks);
            taskManager.getAllTasks(dateCreated);
            taskServiceMock.Expects.One.MethodWith(s => s.getAllTasks()).WillReturn(tasks);
            taskManager.getAllTasks(badSort);
        }


    }
}
