using System.Text.Json;

using TaskTrackerCli.Models;

using TaskStatus = TaskTrackerCli.Enums.TaskStatus;

namespace TaskTrackerCli.Core.Interfaces;

public class CommandParser(List<ICommand> commands)
{
    private readonly List<ICommand> _commands = commands;

    public void Start()
    {
        Console.Clear();

        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Entrada não reconhecida.");
                continue;
            }

            var parameters = input.Split(' ');

            bool isTaskCli = parameters[0] == "task-cli " || parameters[0] == "task-cli";
            if (!isTaskCli)
                continue;

            if (parameters.Length <= 1)
                continue;

            var command = _commands.FirstOrDefault(x => x.Name == parameters[1]);
            if (command is null)
            {
                Console.WriteLine("Comando não reconhecido.");
                continue;
            }

            command.Execute(parameters);
        }
    }
}