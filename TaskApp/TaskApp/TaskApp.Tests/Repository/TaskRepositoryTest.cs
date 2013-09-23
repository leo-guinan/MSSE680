using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;
using TaskApp.Repository;
using System.Data.Entity;           // i needed to add this to get the context reference
using System.Configuration;         // i needed to add this to get the configurationmanager reference (to pull the connection string)


namespace TaskApp.Tests.Repository
{
    [TestClass]
    public class TaskRepositoryTest
    {

        /*
         * Split into only two methods, due to necessity to make sure that items were added, worked with, and removed correctly.
         * */
        private Task task;
        [TestMethod]
        public void testWithRepository()
        {
            DbContext myContext = new DbContext(ConfigurationManager.ConnectionStrings["taskDomainDBEntities"].ConnectionString);
            var taskRepo = new Repository<Task>(myContext);

            task = new Task();
            task.name = "testName";
            task.notes = "notes";
            task.description = "description";

            Assert.IsTrue(taskRepo.addEntity(task));

            Assert.AreNotEqual(0, taskRepo.getAllEntitiesAsList().Count);

            Assert.AreEqual("description", taskRepo.getEntity(task.id).description);
            task.description = "new description";
            Assert.IsTrue(taskRepo.updateEntity(task));

            Assert.AreEqual("new description", taskRepo.getEntity(task.id).description);

            Assert.IsTrue(taskRepo.delete(task));



        }

        [TestMethod]
        public void testWithoutRepository()
        {
            // make a connection to the database - the connection string needed to be added to app.config
            taskDomainDBEntities db = new taskDomainDBEntities();

            task = new Task();
            task.name = "testName";
            task.notes = "notes";
            task.description = "description";

            Assert.IsNotNull(db.Tasks.Add(task));

            Assert.AreNotEqual(0, db.Tasks.Local.Count);

            Assert.AreEqual("description", db.Tasks.Find(task.id).description);
            task.description = "new description";

            Assert.AreEqual("new description", db.Tasks.Find(task.id).description);

            Assert.IsNotNull(db.Tasks.Remove(task));
        }





    }
}
