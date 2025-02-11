using System.Text.Json;

using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.Models;

namespace TaskTrackerCli.src.Features.AddTask
{
    public class ListTaskCommand : ICommand
    {
        public string Name => "list";
    
        public void Execute(string[] parameters)
        {
            if (parameters.Length < 2)
                return;

            string path = "/mnt/c/Projects/TaskTrackerCli/src/Database/task_data.json";
            var options = new JsonSerializerOptions { WriteIndented = true };

            bool fileExists = File.Exists(path);
            if (!fileExists)
                Console.WriteLine($"Task not found. You need to add the task before proceeding.");
            else
            {
                if (parameters.Length != 2)
                    return;

                Console.WriteLine(File.ReadAllText(path));
            }
        }
    }
}