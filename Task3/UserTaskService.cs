using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new ArgumentException("Invalid userId");

            var user = _userDao.GetUser(userId);

            var tasks = user?.Tasks ?? throw new NullReferenceException("User not found");

            foreach (var t in tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("The task already exists");
            }

            tasks.Add(task);
        }
    }
}