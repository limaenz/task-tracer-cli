using TaskTrackerCli.Models;

using TaskStatus = TaskTrackerCli.Enums.TaskStatus;

namespace TaskTrackerCli.src.Common.Interfaces
{
    public interface ITaskRepository
    {
        void GetAll();
        void GetByStatus(TaskStatus taskStatus);
        void Add(TaskModel newTask);
        void Delete(Guid id);
        void UpdateDescription(string description, Guid id);
        void MarkStatus(TaskStatus taskStatus, Guid id);
    }
}