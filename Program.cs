using TaskTrackerCli.Core.Interfaces;
using TaskTrackerCli.src.Common.Interfaces;
using TaskTrackerCli.src.Features.AddTask;
using TaskTrackerCli.src.Features.HelpTask;
using TaskTrackerCli.src.Repositories;

internal class Program
{
  private static void Main()
  {
    ITaskRepository taskRepository = new TaskRepository();

    var commands = new List<ICommand>()
    {
      new AddTaskCommand(taskRepository),
      new HelpTaskCommand(),
      new UpdateTaskCommand(taskRepository),
      new DeleteTaskCommand(taskRepository),
      new MarkDoneTaskCommand(taskRepository),
      new MarkInProgressTaskCommand(taskRepository),
      new ListTaskCommand(taskRepository)
    };

    var commandParser = new CommandParser(commands);
    commandParser.Start();
  }
}