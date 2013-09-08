using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;

namespace TaskApp.Tests
{
    [TestClass]
    public class UserTest
    {
        private User user;
        
        [TestMethod]
        public void testValidateUserValidUser()
        {
            user = new User();
            user.username = "username";
            user.password = "password";
            Assert.IsTrue(user.validateUser());
        }

        [TestMethod]
        public void testValidateUserInvalidUserNullUsername()
        {
            user = new User();
            user.username = null;
            user.password = "password";
            Assert.IsFalse(user.validateUser());
        }

        [TestMethod]
        public void testValidateUserInvalidUserNullPassword()
        {
            user = new User();
            user.username = "username";
            user.password = null;
            Assert.IsFalse(user.validateUser());
        }

        [TestMethod]
        public void testValidateUserInvalidUserNullUsernameNullPassword()
        {
            user = new User();
            user.username = null;
            user.password = null;
            Assert.IsFalse(user.validateUser());
        }
    }
}