using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System.Data.Entity;           // i needed to add this to get the context reference
using System.Configuration;
using TaskApp.Domain;
using TaskApp.Repository;
using TaskApp.Service;
using System.Collections.Generic;
using System.Linq;
namespace TaskApp.Tests.Service
{
    [TestClass]
    public class UserServiceTest {

    
        private UserService userService;
        private Mock<IRepository<User>> mockRepository;
        private MockFactory mockFactory;
        private User user1;
        private User user2;
        private User user3;
        private List<User> users;

        [TestInitialize]
        public void setup()
        {
            user1 = new User();
            user1.username = "testUserAuthenticate";
            user1.password = "password";

            user2 = new User();
            user2.username = "testUserAuthenticate";
            user2.password = "badpassword";

            user3 = new User();
            user3.username = "testUserAuthenticateNotReallyAUser";
            user3.password = "password";

            users = new List<User>();
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            mockFactory = new MockFactory();
            mockRepository = mockFactory.CreateMock<IRepository<User>>();
           
            userService = new UserService(mockRepository.MockObject);

        }

        [TestMethod]
        public void testAddUser()
        {
            mockRepository.Expects.One.MethodWith(r => r.getAllEntities()).WillReturn(users.AsQueryable());

            mockRepository.Expects.One.MethodWith(r => r.addEntity(user1)).WillReturn(true);
            mockRepository.Expects.One.MethodWith(r => r.addEntity(user2)).WillReturn(false);
            Assert.IsTrue(userService.addUser(user1));
            Assert.IsFalse(userService.addUser(user2));
        }

        [TestMethod]
        public void testModifyUser()
        {
            mockRepository.Expects.One.MethodWith(r => r.getAllEntities()).WillReturn(users.AsQueryable());

            mockRepository.Expects.One.MethodWith(r => r.updateEntity(user1)).WillReturn(true);
            mockRepository.Expects.One.MethodWith(r => r.updateEntity(user2)).WillReturn(false);
            Assert.IsTrue(userService.modifyUser(user1));
            Assert.IsFalse(userService.modifyUser(user2));
        }

        [TestMethod]
        public void testRemoveUser()
        {
            mockRepository.Expects.One.MethodWith(r => r.getAllEntities()).WillReturn(users.AsQueryable());
            mockRepository.Expects.One.MethodWith(r => r.delete(user1)).WillReturn(true);
            mockRepository.Expects.One.MethodWith(r => r.delete(user2)).WillReturn(false);
            Assert.IsTrue(userService.removeUser(user1));
            Assert.IsFalse(userService.removeUser(user2));

        }

        [TestMethod]
        public void testAuthenticateUserValidPassword()
        {
            mockRepository.Expects.One.MethodWith(r => r.getEntity(user1.username)).WillReturn(user1);
            Assert.IsTrue(userService.authenticateUser(user1));

        }

        [TestMethod]
        public void testAuthenticateUserInvalidPassword()
        {
            mockRepository.Expects.One.MethodWith(r => r.getEntity(user2.username)).WillReturn(user1);
            Assert.IsFalse(userService.authenticateUser(user2));
        }

        [TestMethod]
        public void testAuthenticateUserInvalidUser()
        {
            mockRepository.Expects.One.MethodWith(r => r.getEntity(user3.username)).WillReturn(null);
            Assert.IsFalse(userService.authenticateUser(user3));
        }
    }
}
