using System;
using TaskManager.Enums;

namespace TaskManager.ViewModels
{
    public class TaskViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime FinishingDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorName { get; set; }
        public string ExecutorName { get; set; }
        public Status Status { get; set; }
    }
}