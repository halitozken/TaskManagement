namespace Services.Contracts
{
    public interface IServiceManager
    {
        ITaskService TaskService { get; }
    }
}