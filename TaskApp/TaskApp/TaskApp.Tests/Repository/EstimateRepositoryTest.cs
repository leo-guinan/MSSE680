using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;
using TaskApp.Repository;
using System.Data.Entity;           // i needed to add this to get the context reference
using System.Configuration;         // i needed to add this to get the configurationmanager reference (to pull the connection string)

namespace TaskApp.Tests.Repository
{
    [TestClass]
    public class EstimateRepositoryTest
    {


        /*
         * Split into only two methods, due to necessity to make sure that items were added, worked with, and removed correctly.
         * */
        private Estimate estimate;
        private Task task;

        [TestMethod]
        public void testWithRepository()
        {
            DbContext myContext = new DbContext(ConfigurationManager.ConnectionStrings["taskDomainDBEntities"].ConnectionString);
            var estimateRepo = new Repository<Estimate>(myContext);

            task = new Task();
            task.name = "testTaskName";
            estimate = new Estimate();
            estimate.Task = task;
            estimate.time = 4;
            estimate.type = "hours";


            Assert.IsTrue(estimateRepo.addEntity(estimate));

            Assert.AreNotEqual(0, estimateRepo.getAllEntitiesAsList().Count);

            Assert.AreEqual(4, estimateRepo.getEntity(estimate.id).time);
            estimate.time = 6;
            Assert.IsTrue(estimateRepo.updateEntity(estimate));

            Assert.AreEqual(6, estimateRepo.getEntity(estimate.id).time);

            Assert.IsTrue(estimateRepo.delete(estimate));



        }

        [TestMethod]
        public void testWithoutRepository()
        {
            // make a connection to the database - the connection string needed to be added to app.config
            taskDomainDBEntities db = new taskDomainDBEntities();
            task = new Task();
            task.name = "testTaskName";
            estimate = new Estimate();
            estimate.Task = task;
            estimate.time = 4;
            estimate.type = "hours";
            Assert.IsNotNull(db.Estimates.Add(estimate));

            Assert.AreNotEqual(0, db.Estimates.Local.Count);

            Assert.AreEqual(4, db.Estimates.Find(estimate.id).time);
            estimate.time = 6;

            Assert.AreEqual(6, db.Estimates.Find(estimate.id).time);

            Assert.IsNotNull(db.Estimates.Remove(estimate));
        }



    }
}
