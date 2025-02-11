using System.Text.Json;

using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.Models;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class MarkDoneTaskCommand : ICommand
    {
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

            string path = "/mnt/c/Projects/TaskTrackerCli/src/Database/task_data.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = string.Empty;
            bool fileExists = File.Exists(path);

            if (!fileExists)
            {
                Console.WriteLine($"Task not found. You need to add the task before proceeding.");
                return;
            }
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

                var currentTask = currentTasks[index];

                if (currentTask.Id == Guid.Empty)
                {
                    Console.WriteLine($"Task not found. You need to add the task before proceeding.");
                    return;
                }

                currentTask.Status = Enums.TaskStatus.Done;

                currentTasks[index] = currentTask;

                json = JsonSerializer.Serialize(currentTasks, options);
                File.Delete(path);
            }

            File.WriteAllText(path, json);
            Console.WriteLine($"Task updated successfully (ID:{id})");
        }
    }
}