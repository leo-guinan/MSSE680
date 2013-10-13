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
        IList<Task> tasks;
        [TestInitialize]
        public void setup()
        {
            tasks = new List<Task>();
            task = new Task();
            tasks.Add(task);           
            mockFactory = new MockFactory();
            taskManager = mockFactory.CreateMock<ITaskManager>();
            controller = new TaskController();
            controller.taskManager = taskManager.MockObject;

        }

        [TestMethod]
        public void TestListAll()
        {
            taskManager.Expects.One.MethodWith(m => m.getAllTasks(null)).WillReturn(tasks);
            ViewResult result = controller.ListAll(null) as ViewResult;
            Assert.AreEqual(1, (result.Model as IList<TaskModel>).Count);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("priority")).WillReturn(tasks);
            result = controller.ListAll("priority") as ViewResult;
            Assert.AreEqual(1, (result.Model as IList<TaskModel>).Count);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("dueDate")).WillReturn(tasks);
            result = controller.ListAll("dueDate") as ViewResult;
            Assert.AreEqual(1, (result.Model as IList<TaskModel>).Count);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("dateCreated")).WillReturn(tasks);
            result = controller.ListAll("dateCreated") as ViewResult;
            Assert.AreEqual(1, (result.Model as IList<TaskModel>).Count);                        
        }

        [TestMethod]
        public void testAdd()
        {
            Mock<TaskModel> mockModel = mockFactory.CreateMock<TaskModel>();
            taskManager.Expects.One.Method(m => m.addTask("", "", "", DateTime.Now, DateTime.Now, 0, 0, "")).WithAnyArguments().WillReturn(true);
            ViewResult result = controller.Add(mockModel.MockObject) as ViewResult;
            Assert.AreEqual("AddSuccess", result.ViewName);
            taskManager.Expects.One.Method(m => m.addTask("", "", "", DateTime.Now, DateTime.Now, 0, 0, "")).WithAnyArguments().WillReturn(false);
            result = controller.Add(mockModel.MockObject) as ViewResult;
            Assert.AreEqual("AddFailure", result.ViewName);
        } 
    }
}
