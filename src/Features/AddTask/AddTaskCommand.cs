using System.Text.Json;

using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.Models;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class AddTaskCommand : ICommand
    {
        public string Name => "add";

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

            var newTask = new TaskModel()
            {
                Id = Guid.NewGuid(),
                Description = taskName,
                Status = Enums.TaskStatus.Todo,
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            if (newTask.IsInvalid())
                return;
                
            var currentTasks = new List<TaskModel>()
            {
                newTask
            };

            string path = "/mnt/c/Projects/TaskTrackerCli/src/Database/task_data.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = string.Empty;
            bool fileExists = File.Exists(path);

            if (!fileExists)
                json = JsonSerializer.Serialize(currentTasks, options);
            else
            {
                currentTasks = JsonSerializer
                    .Deserialize<List<TaskModel>>(File.ReadAllText(path)) ?? [];
                currentTasks.Add(newTask);

                json = JsonSerializer.Serialize(currentTasks, options);
                File.Delete(path);
            }

            File.WriteAllText(path, json);
            Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
        }
    }
}