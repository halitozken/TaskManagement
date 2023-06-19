using Entities.Models;

namespace Services.Contracts
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetAllTasks(bool trackChanges);
        TaskModel GetOneTaskById(int id, bool trackChanges);
        TaskModel CreateOneTask(TaskModel task);
        void UpdateOneTask(int id, TaskModel task, bool trackChanges);
        void DeleteOneTask(int id, bool trackChanges);

    }
}