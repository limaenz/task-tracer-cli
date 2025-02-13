using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.src.Common.Interfaces;

using TaskStatus = TaskTrackerCli.Enums.TaskStatus;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class ListTaskCommand(ITaskRepository taskRepository) : ICommand
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public string Name => "list";

        public void Execute(string[] parameters)
        {
            if (parameters.Length is 2)
                _taskRepository.GetAll();

            if (parameters.Length < 3)
                return;

            string normalizedInput = parameters[2]
                .Replace("-", "")
                .Replace(" ", "")
                .ToLower();

            if (!Enum.TryParse<TaskStatus>(normalizedInput, true, out var status))
            {
                Console.WriteLine("Status not found.");
                return;
            }

            _taskRepository.GetByStatus(status);
        }
    }
}