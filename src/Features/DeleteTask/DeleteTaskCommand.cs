using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.src.Common.Interfaces;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class DeleteTaskCommand(ITaskRepository taskRepository) : ICommand
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public string Name => "delete";

        public void Execute(string[] parameters)
        {
            if (parameters.Length < 3)
                return;

            if (!Guid.TryParse(parameters[2], out Guid id))
            {
                Console.WriteLine($"Task not found. You need to add the task before proceeding.");
                return;
            }

            _taskRepository.Delete(id);
            
            Console.WriteLine($"Task removed successfully (ID: {id})");
        }
    }
}