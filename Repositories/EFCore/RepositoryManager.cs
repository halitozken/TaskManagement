using EFCore.Config;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ITaskRepository> _taskRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(_context));
        }

        public ITaskRepository Task => _taskRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}