using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Domain;

namespace TaskApp.Tests
{
    [TestClass]
    public class EstimateTest

    {
        private Estimate estimate;
        [TestMethod]
        public void testValidEstimate()
        {
            estimate = new Estimate();
            estimate.id = 1;
            estimate.time = 4;
            estimate.type = "hours";
            Assert.IsTrue(estimate.validateEstimate());
        }


        [TestMethod]
        public void testInvalidEstimateNullType()
        {
            estimate = new Estimate();
            estimate.id = 1;
            estimate.time = 4;
            estimate.type = null;
            Assert.IsFalse(estimate.validateEstimate());
        }

     
    }
}
