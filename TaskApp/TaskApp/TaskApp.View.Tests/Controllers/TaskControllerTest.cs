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
        Task task2;
        IList<Task> tasks;
        [TestInitialize]
        public void setup()
        {
            tasks = new List<Task>();
            task = new Task();
            task2 = new Task();
            task.priority = 1;
            task.dateCreated = new DateTime(2013, 1, 1);
            task.dueDate = new DateTime(2013, 2, 1);
            task2.priority = 2;
            task2.dateCreated = new DateTime(2014, 1, 1);
            task2.dueDate = new DateTime(2014, 2, 1);
            tasks.Add(task);
            tasks.Add(task2);
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
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("priority")).WillReturn(tasks);
            result = controller.ListAll("priority") as ViewResult;
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);
            Assert.AreEqual(task.priority, (result.Model as ListAllModel).taskModels[0].priority);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("dueDate")).WillReturn(tasks);
            result = controller.ListAll("dueDate") as ViewResult;
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);
            Assert.AreEqual(task.dueDate, (result.Model as ListAllModel).taskModels[0].dueDate);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("dateCreated")).WillReturn(tasks);
            result = controller.ListAll("dateCreated") as ViewResult;
            Assert.AreEqual(task.dateCreated, (result.Model as ListAllModel).taskModels[0].dateCreated);
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);                        
        }

        [TestMethod]
        public void TestListAllOppositeSort()
        {
            taskManager.Expects.One.MethodWith(m => m.getAllTasks(null)).WillReturn(tasks);
            ViewResult result = controller.ListAll(null) as ViewResult;
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("priority")).WillReturn(tasks);
            result = controller.ListAll("priority", "d") as ViewResult;
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);
            Assert.AreEqual(task.priority, (result.Model as ListAllModel).taskModels[1].priority);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("dueDate")).WillReturn(tasks);
            result = controller.ListAll("dueDate", "d") as ViewResult;
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);
            Assert.AreEqual(task.dueDate, (result.Model as ListAllModel).taskModels[1].dueDate);
            taskManager.Expects.One.MethodWith(m => m.getAllTasks("dateCreated")).WillReturn(tasks);
            result = controller.ListAll("dateCreated", "d") as ViewResult;
            Assert.AreEqual(2, (result.Model as ListAllModel).taskModels.Count);
            Assert.AreEqual(task.dateCreated, (result.Model as ListAllModel).taskModels[1].dateCreated);
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
