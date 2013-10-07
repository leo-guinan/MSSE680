using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.View.Controllers;
using TaskApp.Business;
using NMock;
using TaskApp.Domain;
using System.Collections.Generic;
using System.Web.Mvc;
using TaskApp.View.Models;

namespace TaskApp.View.Tests.Controllers
{
    [TestClass]
    public class TaskControllerTest
    {
        TaskController controller;

        Mock<ITaskManager> taskManager;

        MockFactory mockFactory;
        Task task;

        [TestInitialize]
        public void setup()
        {
            IList<Task> tasks = new List<Task>();
            task = new Task();
            tasks.Add(task);
            mockFactory = new MockFactory();
            taskManager = mockFactory.CreateMock<ITaskManager>();
            taskManager.Expects.One.MethodWith(m => m.getAllTasks()).WillReturn(tasks);

            controller = new TaskController();
            controller.taskManager = taskManager.MockObject;

        }

        [TestMethod]
        public void TestListAll()
        {
            ViewResult result = controller.ListAll() as ViewResult;
            Assert.AreEqual(1, (result.Model as IList<TaskModel>).Count);
            
        }
    }
}
