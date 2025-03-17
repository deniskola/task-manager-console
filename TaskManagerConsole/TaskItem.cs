
namespace TaskManagerConsole
{
    class TaskItem
    {
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; } // Optional due date
        public string Priority { get; set; } = "Normal"; //Low, Normal, High
    }
}
