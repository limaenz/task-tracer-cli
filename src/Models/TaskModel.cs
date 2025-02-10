using TaskStatus = TaskTrackerCli.Enums.TaskStatus;

namespace TaskTrackerCli.Models
{
    public record struct TaskModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public bool IsInvalidDescription()
        {
            if (string.IsNullOrWhiteSpace(Description.Trim('"'))
            || Description.LastOrDefault() != '"'
            || Description.FirstOrDefault() != '"')
                return true;

            Description = Description.Trim('"');
            return false;
        }
    }
}