using System.ComponentModel;

namespace TaskTrackerCli.Enums
{
    public enum TaskStatus
    {
        [Description("todo")]
        Todo,
        [Description("in-progress")]
        InProgress,
        [Description("done")]
        Done
    }
}