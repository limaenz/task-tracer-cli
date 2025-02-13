using System.Text.Json;

using TaskTrackerCli.Models;
using TaskTrackerCli.src.Common.Interfaces;

using TaskStatus = TaskTrackerCli.Enums.TaskStatus;

namespace TaskTrackerCli.src.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly string _path;
    private readonly JsonSerializerOptions _options;

    public TaskRepository()
    {
        _path = "/mnt/c/Projects/TaskTrackerCli/src/Database/task_data.json";
        _options = new JsonSerializerOptions { WriteIndented = true };
    }

    public void Add(TaskModel newTask)
    {
        var currentTasks = new List<TaskModel>()
        {
            newTask
        };

        string json;
        if (!File.Exists(_path))
            json = JsonSerializer.Serialize(currentTasks, _options);
        else
        {
            currentTasks = JsonSerializer
                .Deserialize<List<TaskModel>>(File.ReadAllText(_path)) ?? [];
            currentTasks.Add(newTask);

            json = JsonSerializer.Serialize(currentTasks, _options);
            File.Delete(_path);
        }

        File.WriteAllText(_path, json);
    }

    public void Delete(Guid id)
    {
        string json = string.Empty;

        if (!File.Exists(_path))
            Console.WriteLine($"Task not found. You need to add the task before proceeding.");
        else
        {
            var currentTasks = JsonSerializer
                .Deserialize<List<TaskModel>>(File.ReadAllText(_path)) ?? [];

            var index = currentTasks.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                Console.WriteLine($"Task not found. You need to add the task before proceeding.");
                return;
            }

            currentTasks.RemoveAt(index);

            json = JsonSerializer.Serialize(currentTasks, _options);
            File.Delete(_path);
        }

        File.WriteAllText(_path, json);
    }

    public void GetAll()
    {
        if (!File.Exists(_path))
            Console.WriteLine($"No tasks available. Add a new task to get started!");

        Console.WriteLine(File.ReadAllText(_path));
        return;
    }

    public void GetByStatus(TaskStatus taskStatus)
    {
        var currentTasks = JsonSerializer
            .Deserialize<List<TaskModel>>(File.ReadAllText(_path)) ?? [];

        var tasks = currentTasks.Where(x => x.Status == taskStatus);
        if (!tasks.Any())
        {
            Console.WriteLine($"No tasks available. Add a new task to get started!");
            return;
        }

        Console.WriteLine(JsonSerializer.Serialize(tasks, _options));
    }

    public void MarkStatus(TaskStatus taskStatus, Guid id)
    {
        string json = string.Empty;

        if (!File.Exists(_path))
        {
            Console.WriteLine($"Task not found. You need to add the task before proceeding.");
            return;
        }
        else
        {
            var currentTasks = JsonSerializer
                .Deserialize<List<TaskModel>>(File.ReadAllText(_path)) ?? [];

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

            currentTask.Status = taskStatus;

            currentTasks[index] = currentTask;

            json = JsonSerializer.Serialize(currentTasks, _options);
            File.Delete(_path);
        }

        File.WriteAllText(_path, json);
    }

    public void UpdateDescription(string description, Guid id)
    {
        string json = string.Empty;

        if (!File.Exists(_path))
        {
            Console.WriteLine($"Task not found. You need to add the task before proceeding.");
            return;
        }
        else
        {
            var currentTasks = JsonSerializer
                .Deserialize<List<TaskModel>>(File.ReadAllText(_path)) ?? [];

            var index = currentTasks.FindIndex(x => x.Id == id);

            if (index == -1)
                return;

            var currentTask = currentTasks[index];

            if (currentTask.Id == Guid.Empty)
            {
                Console.WriteLine($"Task not found.");
                return;
            }

            currentTask.Description = description;
            currentTask.UpdateAt = DateTime.Now;

            if (currentTask.IsInvalidDescription())
                return;

            currentTasks[index] = currentTask;

            json = JsonSerializer.Serialize(currentTasks, _options);
            File.Delete(_path);
        }

        File.WriteAllText(_path, json);
        Console.WriteLine($"Task updated successfully (ID:{id})");
    }
}