namespace Repositories.Contracts
{
    public interface IRepositoryManager {
        ITaskRepository Task {get;}
        void Save();
    }
}