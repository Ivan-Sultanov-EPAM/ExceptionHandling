using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public void AddTaskForUser(int userId, string description)
        {
            var task = new UserTask(description);
            _taskService.AddTaskForUser(userId, task);
        }
    }
}