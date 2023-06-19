using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITaskService> _taskService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _taskService = new Lazy<ITaskService>(() => new TaskManager(repositoryManager));
        }

        public ITaskService TaskService => _taskService.Value;
    }
}