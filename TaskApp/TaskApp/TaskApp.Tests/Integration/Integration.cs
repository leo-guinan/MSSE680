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
        private static ServiceFactory factory = new ServiceFactory();
        private ITaskService taskService = factory.getTaskService();
        private IUserService userService = factory.getUserService();

        [TestMethod]
        public void testFlowFromServiceFactoryToGetDomainObjectsTask()
        {
            Task task = new Task();
            task.description = "description";
            task.name = "testTask";
            task.notes = "taskNotes";
            task.id = 999;
            task.estimateId = 999;
            Estimate estimate = new Estimate();
            estimate.id = 999;
            estimate.time = 5;
            estimate.type = "hours";
            task.Estimate = estimate;
            Assert.IsTrue(taskService.addTask(task));
            Assert.AreEqual(taskService.getTaskById(task.id).name, "testTask");
            task.name = "newTaskName";
            Assert.IsTrue(taskService.modifyTask(task));
            Assert.AreEqual(taskService.getTaskById(task.id).name, "newTaskName");
            Assert.AreEqual(taskService.getTaskById(999), task);
            Assert.IsTrue(taskService.getAllTasks().Count > 0);
            Assert.IsTrue(taskService.removeTask(task));
            Assert.IsNull(taskService.getTaskById(999));

            //This should not be needed. Problem with relationship. Will be remedied during next release cycle.
            IRepository<Estimate> estimateRepository = new Repository<Estimate>(new taskDomainDBEntities());
            estimate = estimateRepository.getEntity(999);
            estimateRepository.delete(estimate);

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
