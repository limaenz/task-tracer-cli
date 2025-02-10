
using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.src.Features.AddTask;
using TaskTrackerCli.src.Features.HelpTask;

internal class Program
{
  private static void Main()
  {
    var commands = new List<ICommand>()
    {
      new AddTaskCommand(),
      new HelpTaskCommand(),
      new UpdateTaskCommand()
    };

    var commandParser = new CommandParser(commands);
    commandParser.Start();
  }
}