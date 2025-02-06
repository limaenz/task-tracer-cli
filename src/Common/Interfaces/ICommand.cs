namespace TaskTrackerCli.Core.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        void Execute(string[] parameters);
    }
}