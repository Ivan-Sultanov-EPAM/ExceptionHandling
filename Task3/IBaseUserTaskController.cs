namespace Task3
{
    public interface IBaseUserTaskController
    {
        void AddTaskForUser(int userId, string description);
    }
}