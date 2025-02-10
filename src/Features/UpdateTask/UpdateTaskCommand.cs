using System.Text.Json;

using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.Models;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class UpdateTaskCommand : ICommand
    {
        public string Name => "update";

        public void Execute(string[] parameters)
        {
            string taskName = string.Empty;
            bool isTaskName = false;

            foreach (var item in parameters)
            {
                if (item.StartsWith('"') || item.EndsWith('"'))
                    isTaskName = true;

                if (!isTaskName)
                    continue;

                taskName += parameters[^1].Equals(item)
                ? item
                : item + " ";
            }

            if (parameters.Length < 4)
                return;

            string path = "/mnt/c/Projects/TaskTrackerCli/src/Database/task_data.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = string.Empty;
            bool fileExists = File.Exists(path);
            Guid id;

            if (!fileExists)
            {
                Console.WriteLine($"Task not found. You need to add the task before proceeding.");
                return;
            }
            else
            {
                var currentTasks = JsonSerializer
                    .Deserialize<List<TaskModel>>(File.ReadAllText(path)) ?? [];

                if (!Guid.TryParse(parameters[2], out id))
                    return;

                var index = currentTasks.FindIndex(x => x.Id == id);

                if (index == -1)
                    return;

                var currentTask = currentTasks[index];

                if (currentTask.Id == Guid.Empty)
                {
                    Console.WriteLine($"Task not found.");
                    return;
                }

                currentTask.Description = taskName;
                currentTask.UpdateAt = DateTime.Now;

                if (currentTask.IsInvalidDescription())
                    return;

                currentTasks[index] = currentTask;    

                json = JsonSerializer.Serialize(currentTasks, options);
                File.Delete(path);
            }

            File.WriteAllText(path, json);
            Console.WriteLine($"Task updated successfully (ID:{id})");
        }
    }
}