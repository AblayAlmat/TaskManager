using TaskManager.Enums;

namespace TaskManager.ViewModels
{
    public class StatusChangeViewModel
    {
        public string TaskId { get; set; }
        public Status CurrentStatus { get; set; }
        public string ExecutorId { get; set; }
    }
}