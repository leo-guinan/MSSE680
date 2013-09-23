using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Comparer;
using TaskApp.Domain;
using System.Collections.Generic;

namespace TaskApp.Tests.Comparer
{
    [TestClass]
    public class DueDateTaskComparerTest
    {

        private IComparer<Task> comparer;

        private Task task1;
        private Task task2;
        private Task task3;
        

        [TestInitialize]
        public void setup() 
        {
            comparer = new DueDateTaskComparer();
            task1 = new Task();
            task2 = new Task();
            task3 = new Task();

            task1.name = "task1";
            task1.dueDate = new DateTime(2013, 1, 1);

            task2.name = "task2";
            task2.dueDate = new DateTime(2012, 1, 1);

            task3.name = "task3";
            task3.dueDate = new DateTime(2012, 1, 1);


        }

        [TestMethod]
        public void TestComparer()
        {
            Assert.AreEqual(1, comparer.Compare(task1, task2));
            Assert.AreEqual(-1, comparer.Compare(task2, task1));
            Assert.AreEqual(0, comparer.Compare(task2, task3));
        }

    }
}
