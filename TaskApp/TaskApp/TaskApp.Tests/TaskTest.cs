using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;

namespace TaskApp.Tests
{
    [TestClass]
    public class TaskTest
    {
        private Task task = new Task();

        [TestMethod]
        public void testValidTask()
        {
            task.name = "taskName";
                
            task.estimateId = 1;
            task.id = 1;
            Assert.IsTrue(task.validateTask());
        }

        [TestMethod]
        public void testInvalidTaskNullName()
        {
            task.name = null;

            task.estimateId = 1;
            task.id = 1;
            Assert.IsFalse(task.validateTask());
        }

     
    }
}
