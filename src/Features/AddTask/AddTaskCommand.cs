using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.Models;
using TaskTrackerCli.src.Common.Interfaces;
using TaskTrackerCli.src.Common.Utils;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class AddTaskCommand(ITaskRepository taskRepository) : ICommand
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public string Name => "add";

        public void Execute(string[] parameters)
        {
            var newTask = new TaskModel()
            {
                Id = Guid.NewGuid(),
                Description = StringArrayUtils.GetTaskName(parameters),
                Status = Enums.TaskStatus.Todo,
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            if (newTask.IsInvalidDescription())
            {
                Console.WriteLine("Invalid description.");
                return;
            }

            _taskRepository.Add(newTask);

            Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
        }
    }
}