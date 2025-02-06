using TaskTrackerCli.Core.Interfaces;

namespace TaskTrackerCli.src.Features.HelpTask
{
    public class HelpTaskCommand : ICommand
    {
        public string Name => "help";

        public void Execute(string[] parameters)
        {
            bool operationHelp = parameters[1] == "help";
            if (!operationHelp)
                return;

            Console.WriteLine(
        $@"
Usage: task-cli [operations] ""task name""

Operations:
add         Adding a new task.
            ");
        }
    }
}