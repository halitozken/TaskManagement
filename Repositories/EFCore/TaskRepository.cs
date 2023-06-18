using EFCore.Config;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TaskRepository : RepositoryBase<TaskModel>, ITaskRepository
    {
        public TaskRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneTask(TaskModel task) => Create(task);

        public void DeleteOneTask(TaskModel task) => Delete(task);
        public IQueryable<TaskModel> GetAllTasks(bool trackChanges) => FindAll(trackChanges);

        public TaskModel? GetOneTaskById(int id, bool trackChanges) =>
            FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneTask(TaskModel task) => Update(task);

    
    }
}