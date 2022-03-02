using System;
using System.ComponentModel.DataAnnotations;
using TaskManager.Enums;

namespace TaskManager.ViewModels
{
    public class TaskCreateViewModel
    {
        [Required(ErrorMessage = "Введите название задачи")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание задачи")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Выберите приоритет задачи")]
        public Priority Priority { get; set; }
        [Required(ErrorMessage = "Введите дату дедлайна задачи")]
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }
        public Status Status { get; set; }
    }
}