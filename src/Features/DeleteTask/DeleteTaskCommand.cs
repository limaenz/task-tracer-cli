using System.Text.Json;

using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.Models;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class DeleteTaskCommand : ICommand
    {
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

            string path = "/mnt/c/Projects/TaskTrackerCli/src/Database/task_data.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = string.Empty;
            bool fileExists = File.Exists(path);

            if (!fileExists)
                Console.WriteLine($"Task not found. You need to add the task before proceeding.");
            else
            {
                var currentTasks = JsonSerializer
                    .Deserialize<List<TaskModel>>(File.ReadAllText(path)) ?? [];

                var index = currentTasks.FindIndex(x => x.Id == id);

                if (index == -1)
                {
                    Console.WriteLine($"Task not found. You need to add the task before proceeding.");
                    return;
                }

                currentTasks.RemoveAt(index);

                json = JsonSerializer.Serialize(currentTasks, options);
                File.Delete(path);
            }

            File.WriteAllText(path, json);
            Console.WriteLine($"Task removed successfully (ID: {id})");
        }
    }
}