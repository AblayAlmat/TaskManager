using System.Collections.Generic;
using TaskManager.ViewModels;

namespace TaskManager.Services.TaskService
{
    public interface ITaskService
    {
        public List<TaskViewModel> GetAllTaskViewModels();
    }
}