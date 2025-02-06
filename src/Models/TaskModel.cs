using TaskStatus = TaskTrackerCli.Enums.TaskStatus;

namespace TaskTrackerCli.Models
{
    public record struct TaskModel
    {
        public Guid Id  { get; set; }
        public string Description  { get; set; }
        public TaskStatus Status  { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt  { get; set; }                                
    }
}