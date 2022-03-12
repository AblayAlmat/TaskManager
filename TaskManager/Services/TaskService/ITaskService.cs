using System.Collections.Generic;
using TaskManager.ViewModels;

namespace TaskManager.Services.TaskService
{
    public interface ITaskService
    {
        public List<TaskViewModel> GetAllTaskViewModels();
        public void CreateTask(TaskCreateViewModel model);
        public TaskViewModel GetDetails(string id);
        public void ChangeStatus(StatusChangeViewModel model);
    }
}