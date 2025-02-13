using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.src.Common.Interfaces;
using TaskTrackerCli.src.Common.Utils;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class UpdateTaskCommand(ITaskRepository taskRepository) : ICommand
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public string Name => "update";

        public void Execute(string[] parameters)
        {
            if (parameters.Length < 4)
                return;

            if (!Guid.TryParse(parameters[2], out Guid id))
                return;

            _taskRepository.UpdateDescription(StringArrayUtils.GetTaskName(parameters), id);
        }
    }
}