﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TaskApp.Comparer;
using TaskApp.Domain;


namespace TaskApp.Tests.Comparer
{
    [TestClass]
    public class DateCreatedTaskComparerTest
    {
        private IComparer<Task> comparer;

        private Task task1;
        private Task task2;
        private Task task3;


        [TestInitialize]
        public void setup()
        {
            comparer = new DateCreatedTaskComparer();
            task1 = new Task();
            task2 = new Task();
            task3 = new Task();

            task1.name = "task1";
            task1.dateCreated = new DateTime(2013, 1, 1);

            task2.name = "task2";
            task2.dateCreated = new DateTime(2012, 1, 1);

            task3.name = "task3";
            task3.dateCreated = new DateTime(2012, 1, 1);


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
