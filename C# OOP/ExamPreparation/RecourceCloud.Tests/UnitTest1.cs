using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        private DepartmentCloud departmentCloud;
        [SetUp]
        public void Setup()
        {
            departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void CtorDepartmentCloud_CreatesInstance()
        {
            Assert.IsNotNull(departmentCloud.Resources);
            Assert.IsNotNull(departmentCloud.Tasks);
        }

        [Test]
        public void LogTask_CreatesTask()
        {
            string actual = departmentCloud.LogTask(new[] { "1", "Assigned", "Task 1 Details" });
            string expected = $"Task logged successfully.";
            
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTask_NotEnoughArguments_ThrowsException()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => departmentCloud.LogTask(new[] { "1", "Assigned" }));

            Assert.That(ae.Message, Is.EqualTo("All arguments are required."));

            Assert.AreEqual(0, departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTask_NullArgument_ThrowsException()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => departmentCloud.LogTask(new[] { "1", "Assigned", null}));

            Assert.That(ae.Message, Is.EqualTo("Arguments values cannot be null."));

            Assert.AreEqual(0, departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTask_TaskAlreadyExist_ThrowsException()
        {
            departmentCloud.LogTask(new[] { "1", "Assigned", "Task 1 Details" });

            string actual = departmentCloud.LogTask(new[] { "1", "Assigned", "Task 1 Details" });
            string expected = "Task 1 Details is already logged.";


            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, departmentCloud.Tasks.Count);
        }

        [Test]
        public void CreateResource_ReturnsTrue()
        {
            //Task task = new Task(1, "Assigned", "Task 1 Details");

            departmentCloud.LogTask(new[] { "1", "Assigned", "Task 1 Details" });
            departmentCloud.LogTask(new[] { "2", "Assigned", "Task 2 Details" });

            Assert.AreEqual(2, departmentCloud.Tasks.Count);
            Assert.AreEqual(0, departmentCloud.Resources.Count);

            bool actual = departmentCloud.CreateResource();

            Assert.IsTrue(actual);
            Assert.AreEqual(1, departmentCloud.Tasks.Count);
            Assert.AreEqual(1, departmentCloud.Resources.Count);
        }

        [Test]
        public void CreateResource_ReturnsFalse()
        {
            Assert.IsFalse(departmentCloud.CreateResource());
        }

        [Test]
        public void TestResource_TestsTesourse_True()
        {
            //Task task = new Task(1, "Assigned", "Task 1 Details");

            departmentCloud.LogTask(new[] { "1", "Assigned", "Task 1 Details" });

            departmentCloud.CreateResource();

            Resource resource = departmentCloud.TestResource("Task 1 Details");
            Assert.IsTrue(resource.IsTested);
        }

        [Test]
        public void TestResource_TestsTesourse_False()
        {
            departmentCloud.LogTask(new[] { "1", "Assigned", "Task 1 Details" });

            departmentCloud.CreateResource();

            Resource resource = departmentCloud.TestResource("Task 2 Details");
            Assert.IsNull(resource);
        }
    }
}