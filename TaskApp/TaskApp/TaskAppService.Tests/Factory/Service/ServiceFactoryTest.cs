using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Factory.Service;
using TaskApp.Service;


namespace TaskAppService.Tests.Factory.Service
{
    [TestClass]
    public class ServiceFactoryTest
    {

        ServiceFactory factory;

        [TestInitialize]
        public void setup()
        {
             factory = ServiceFactory.Instance;

        }

        [TestMethod]
        public void TestFactoryIsSingleton()
        {
            ServiceFactory factory2 = ServiceFactory.Instance;
            Assert.ReferenceEquals(factory, factory2);

        }

        [TestMethod]
        public void TestGetUserService()
        {
            Assert.IsInstanceOfType(factory.getService("userService"), typeof(UserService));
        }

        [TestMethod]
        public void TestGetTaskService()
        {
            Assert.IsInstanceOfType(factory.getService("taskService"), typeof(TaskService));

        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestBadGetService()
        {
            factory.getService("NotARealService");   
        }

    }
}
