using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.src.Common.Interfaces;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class MarkDoneTaskCommand(ITaskRepository taskRepository) : ICommand
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public string Name => "mark-done";

        public void Execute(string[] parameters)
        {
            if (parameters.Length < 3)
                return;

            if (!Guid.TryParse(parameters[2], out Guid id))
            {
                Console.WriteLine($"Task not found. You need to add the task before proceeding.");
                return;
            }

            _taskRepository.MarkStatus(Enums.TaskStatus.Done, id);
            Console.WriteLine($"Task updated successfully (ID:{id})");
        }
    }
}