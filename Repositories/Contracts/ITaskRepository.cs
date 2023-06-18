using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITaskRepository{
        IQueryable<TaskModel> GetAllTasks(bool trackChanges);
        TaskModel? GetOneTaskById(int id, bool trackChanges);
        void CreateOneTask(TaskModel task);
        void UpdateOneTask(TaskModel task);
        void DeleteOneTask(TaskModel task);
    }
}