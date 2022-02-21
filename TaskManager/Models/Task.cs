

using System;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime FinishingDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}