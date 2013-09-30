using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;
using TaskApp.Factory.Service;
using TaskApp.Repository;
using TaskApp.Service;

namespace TaskApp.Tests.Integration
{
    [TestClass]
    public class Integration
    {
        private static ServiceFactory factory = ServiceFactory.Instance;
        private ITaskService taskService = (ITaskService) factory.getService("taskService");
        private IUserService userService = (IUserService) factory.getService("userService");

        [TestMethod]
        public void testFlowFromServiceFactoryToGetDomainObjectsTask()
        {
            Task task = new Task();
            task.description = "description";
            task.name = "testTask";
            task.notes = "taskNotes";
            Estimate estimate = new Estimate();
            estimate.time = 5;
            estimate.type = "hours";
            estimate.Task = task;
            Assert.IsTrue(taskService.addTask(task));
            Assert.AreEqual(taskService.getTaskById(task.id).name, "testTask");
            task.name = "newTaskName";
            Assert.IsTrue(taskService.modifyTask(task));
            Assert.AreEqual(taskService.getTaskById(task.id).name, "newTaskName");
            Assert.AreEqual(taskService.getTaskById(task.id), task);
            Assert.IsTrue(taskService.getAllTasks().Count > 0);
            Assert.IsTrue(taskService.removeTask(task));
            Assert.IsNull(taskService.getTaskById(999));

            

        }

        [TestMethod]
        public void testFlowFromServiceFactoryToGetDomainObjectsUser()
        {
            User user = new User();
            user.username = "TESTUserName";
            user.password = "password";
            Assert.IsTrue(userService.addUser(user));
            Assert.AreEqual("password", userService.getUserById("TESTUserName").password);
            user.password = "newPassword";
            Assert.IsTrue(userService.modifyUser(user));
            Assert.AreEqual("newPassword", userService.getUserById("TESTUserName").password);
            Assert.IsTrue(userService.getAllUsers().Count > 0);
            Assert.IsTrue(userService.removeUser(user));
            Assert.IsNull(userService.getUserById(user.username));
        }
    }
}
