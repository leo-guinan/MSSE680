using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using TaskApp.Domain;
using TaskApp.Factory.Service;
using TaskApp.Service;

namespace TaskApp.Business.Tests.Business
{
    [TestClass]
    public class UserManagerTest
    {
        MockFactory mockFactory;
        Mock<IServiceFactory> serviceFactoryMock;
        Mock<IUserService> userServiceMock;

        IUserManager userManager;

        private static readonly String username = "username";
        private static readonly String password = "password";

        
        User user;
        [TestInitialize]
        public void setup()         
        {
            mockFactory = new MockFactory();
            serviceFactoryMock = mockFactory.CreateMock<IServiceFactory>();
            userServiceMock = mockFactory.CreateMock<IUserService>();
            user = new User(username, password);                     
            serviceFactoryMock.Expects.One.MethodWith(f => f.getService("userService")).WillReturn((IService)userServiceMock.MockObject);
            userManager = new UserManager(serviceFactoryMock.MockObject);

        }


        [TestMethod]
        public void TestLogin()
        {
            userServiceMock.Expects.One.Method(s => s.authenticateUser(user)).WithAnyArguments().WillReturn(true);
            Assert.IsTrue(userManager.login(username, password));
        }
    }
}
