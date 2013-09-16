using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;
using TaskApp.Factory.Service;
using TaskApp.Service;
namespace TaskApp.Tests.Integration
{
    [TestClass]
    public class Integration
    {
        private static ServiceFactory factory = new ServiceFactory();
        private ITaskService taskService = factory.getTaskService();

        [TestMethod]
        public void testFlowFromServiceFactoryToGetDomainObjects()
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
            task.name = "newTaskName";
            Assert.IsTrue(taskService.modifyTask(task));
            Assert.IsTrue(taskService.removeTask(task));

        }
    }
}
