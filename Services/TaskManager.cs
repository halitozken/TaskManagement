using System.Reflection.Metadata;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TaskManager : ITaskService
    {
        private readonly IRepositoryManager _manager;

        public TaskManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public TaskModel CreateOneTask(TaskModel task)
        {
            _manager.Task.CreateOneTask(task);
            _manager.Save();
            return task;
        }

        public void DeleteOneTask(int id, bool trackChanges)
        {
            var entity = _manager.Task.GetOneTaskById(id, trackChanges) ?? throw new Exception($"The book with id:{id} could not found");

            _manager.Task.DeleteOneTask(entity);
            _manager.Save();
        }

        public IEnumerable<TaskModel> GetAllTask(bool trackChanges)
        {
            return _manager.Task.GetAllTasks(trackChanges);
        }

        public TaskModel GetOneTaskById(int id, bool trackChanges)
        {
            return _manager.Task.GetOneTaskById(id, trackChanges) ?? throw new Exception($"The book with id:{id} could not found");
        }

        public void UpdateOneTask(int id, TaskModel task, bool trackChanges)
        {
            var entity = _manager.Task.GetOneTaskById(id, trackChanges) ?? throw new Exception($"The book with id:{id} could not found");

            entity.Title = task.Title;
            entity.Description = task.Description;
            entity.StartDateTime = task.StartDateTime;
            entity.EndDateTime = task.EndDateTime;
            entity.Mentions = task.Mentions;
            entity.Status = task.Status;
            entity.Workspace = task.Workspace;

            _manager.Task.UpdateOneTask(entity); //!

            _manager.Save();
        }
    }
}