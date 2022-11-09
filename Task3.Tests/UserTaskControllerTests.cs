using NUnit.Framework;
using System;
using Task3.DoNotChange;
using Task3.Tests.Stubs;

namespace Task3.Tests
{
    [TestFixture]
    public class UserTaskControllerTests
    {
        private readonly IBaseUserTaskController _controller;
        private readonly IUserDao _userDao;

        public UserTaskControllerTests()
        {
            _userDao = new UserDaoStub();
            var taskService = new UserTaskService(_userDao);
            _controller = new UserTaskController(taskService);
        }

        [Test]
        public void CreateUserTask_With_ValidData_Successfully()
        {
            string description = "task4";
            int userId = 1;

            _controller.AddTaskForUser(userId, description);

            Assert.That(_userDao.GetUser(userId).Tasks.Count, Is.EqualTo(4));
            StringAssert.AreEqualIgnoringCase(_userDao.GetUser(userId).Tasks[3].Description, description);
        }

        [Test]
        public void CreateUserTask_With_InvalidUserId_Throws_ArgumentException_With_InvalidUserId_Message()
        {
            string description = "task4";
            int userId = -11, existingUserId = 1;

            Assert.That(() => _controller.AddTaskForUser(userId, description),
                Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Invalid userId"));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_With_NonExistentUser_Throws_NullReferenceException_With_UserNotFound_Message()
        {
            string description = "task4";
            int userId = 2, existingUserId = 1;

            Assert.That(() => _controller.AddTaskForUser(userId, description),
                Throws.InstanceOf<NullReferenceException>().With.Message.EqualTo("User not found"));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_With_Existing_Task_Throws_ArgumentException_With_TheTaskAlreadyExists_Message()
        {
            string description = "task3";
            int userId = 1;

            Assert.That(() => _controller.AddTaskForUser(userId, description),
                Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("The task already exists"));
            Assert.That(_userDao.GetUser(userId).Tasks.Count, Is.EqualTo(3));
        }
    }
}