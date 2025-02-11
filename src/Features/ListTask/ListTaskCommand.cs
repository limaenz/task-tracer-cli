using System.Text.Json;

using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.Models;

using TaskStatus = TaskTrackerCli.Enums.TaskStatus;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class ListTaskCommand : ICommand
    {
        public string Name => "list";

        public void Execute(string[] parameters)
        {
            string path = "/mnt/c/Projects/TaskTrackerCli/src/Database/task_data.json";

            bool fileExists = File.Exists(path);
            if (!fileExists)
                Console.WriteLine($"No tasks available. Add a new task to get started!");

            if (parameters.Length is 2)
            {
                Console.WriteLine(File.ReadAllText(path));
                return;
            }

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

            var currentTasks = JsonSerializer
                .Deserialize<List<TaskModel>>(File.ReadAllText(path)) ?? [];

            var tasks = currentTasks.Where(x => x.Status == status);
            if (!tasks.Any())
            {
                Console.WriteLine($"No tasks available. Add a new task to get started!");
                return;
            }
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(JsonSerializer.Serialize(tasks, options));
        }
    }
}