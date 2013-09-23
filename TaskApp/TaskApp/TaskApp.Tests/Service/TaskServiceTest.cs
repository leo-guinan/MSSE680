using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using TaskApp.Domain;
using TaskApp.Repository;
using TaskApp.Service;
using System.Collections.Generic;
using System.Linq;

namespace TaskApp.Tests.Service
{
    [TestClass]
    public class TaskServiceTest
    {
        private Mock<IRepository<Task>> mockRepository;
        private MockFactory mockFactory;

        private ITaskService taskService;

        private Task task1;
        private Task task2;
        private Task task3;

        [TestInitialize]
        public void setup()
        {
            List<Task> tasks = new List<Task>();
            
            task1 = new Task();
            task1.name = "task1";
            task1.priority = 1;
            task1.dateCreated = new DateTime(2013, 1, 1);
            task1.dueDate = new DateTime(2014, 1, 1);
            
            task2 = new Task();
            task2.name = "task2";
            task2.priority = 2;
            task2.dateCreated = new DateTime(2012, 1, 1);
            task2.dueDate = new DateTime(2013, 1, 1); 
            
            task3 = new Task();
            task3.name = "task1";
            task3.priority = 3;
            task3.dateCreated = new DateTime(2011, 1, 1);
            task3.dueDate = new DateTime(2012, 1, 1);
            
            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);

            
            mockFactory = new MockFactory();
            mockRepository = mockFactory.CreateMock<IRepository<Task>>();
            mockRepository.Expects.One.MethodWith(r => r.getAllEntities()).WillReturn(tasks.AsQueryable());
            taskService = new TaskService(mockRepository.MockObject);

        }

        [TestMethod]
        public void testAddTask()
        {
            mockRepository.Expects.One.MethodWith(r => r.addEntity(task1)).WillReturn(true);
            mockRepository.Expects.One.MethodWith(r => r.addEntity(task2)).WillReturn(false);

            Assert.IsTrue(taskService.addTask(task1));
            Assert.IsFalse(taskService.addTask(task2));
        }

        [TestMethod]
        public void testModifyTask()
        {
            mockRepository.Expects.One.MethodWith(r => r.updateEntity(task1)).WillReturn(true);
            mockRepository.Expects.One.MethodWith(r => r.updateEntity(task2)).WillReturn(false);

            Assert.IsTrue(taskService.modifyTask(task1));
            Assert.IsFalse(taskService.modifyTask(task2));
        }

        [TestMethod]
        public void testGetTaskById()
        {
            mockRepository.Expects.One.MethodWith(r => r.getEntity(1)).WillReturn(task1);
            mockRepository.Expects.One.MethodWith(r => r.getEntity(2)).WillReturn(task2);

            Assert.AreEqual(task1, taskService.getTaskById(1));
            Assert.AreEqual(task2, taskService.getTaskById(2));
        }

        [TestMethod]
        public void testGetAllTasks()
        {
            List<Task> tasks = taskService.getAllTasks();
            Assert.AreEqual(3, tasks.Count);
        }

        [TestMethod]
        public void testRemoveTask()
        {
            mockRepository.Expects.One.MethodWith(r => r.delete(task1)).WillReturn(true);
            mockRepository.Expects.One.MethodWith(r => r.delete(task2)).WillReturn(false);

            Assert.IsTrue(taskService.removeTask(task1));
            Assert.IsFalse(taskService.removeTask(task2));
        }

        [TestMethod]
        public void testSortByPriority()
        {   
            List<Task> tasks = taskService.getAllTasksByPriority();
            Assert.IsTrue(tasks[0].priority < tasks[1].priority);
            Assert.IsTrue(tasks[1].priority < tasks[2].priority);
        }

        [TestMethod]
        public void testSortByDateCreated()
        {
            List<Task> tasks = taskService.getAllTasksByDateCreated();
            Assert.IsTrue(tasks[0].dateCreated < tasks[1].dateCreated);
            Assert.IsTrue(tasks[1].dateCreated < tasks[2].dateCreated);
        }

        [TestMethod]
        public void testSortByDueDate()
        {
            List<Task> tasks = taskService.getAllTasksByDueDate();
            Assert.IsTrue(tasks[0].dueDate < tasks[1].dueDate);
            Assert.IsTrue(tasks[1].dueDate < tasks[2].dueDate);
        }
    }
}
