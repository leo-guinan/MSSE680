using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;
using TaskApp.Repository;
using System.Data.Entity;           // i needed to add this to get the context reference
using System.Configuration;         // i needed to add this to get the configurationmanager reference (to pull the connection string)
using System.Collections.Generic;

namespace TaskApp.Tests.Repository
{
    [TestClass]
    public class UserRepositoryTest
    {

        private User user;

        /*
         * Split into only two methods, due to necessity to make sure that items were added, worked with, and removed correctly.
         * */

        [TestMethod]
        public void testWithRepository()
        {
            DbContext myContext = new DbContext(ConfigurationManager.ConnectionStrings["taskDomainDBEntities"].ConnectionString);
            var userRepo = new Repository<User>(myContext);

            user = new User();
            user.username = "nameRepo";
            user.password = "password";

            Assert.IsNotNull(userRepo.addEntity(user));

            Assert.AreNotEqual(0, userRepo.getAllEntitiesAsList().Count);

            Assert.AreEqual(user.username, userRepo.getEntity("nameRepo").username);
            user.password = "newPassword";
            Assert.IsNotNull(userRepo.updateEntity(user));

            Assert.AreEqual(user.password, userRepo.getEntity("nameRepo").password);

            Assert.IsTrue(userRepo.delete(user));



        }

        [TestMethod]
        public void testWithoutRepository()
        {
            // make a connection to the database - the connection string needed to be added to app.config
            taskDomainDBEntities db = new taskDomainDBEntities();

            user = new User();
            user.username = "nameNoRepo";
            user.password = "password";

            Assert.IsNotNull(db.Users.Add(user));

            Assert.AreNotEqual(0, db.Users.Local.Count);

            Assert.AreEqual(user.username, db.Users.Find(user.username).username);
            user.password = "newPassword";

            Assert.AreEqual("newPassword", db.Users.Find(user.username).password);

            Assert.IsNotNull(db.Users.Remove(user));
        }

       
    }
}
