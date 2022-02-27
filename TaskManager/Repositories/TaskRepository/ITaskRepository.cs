using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.Repositories.TaskRepository
{
    public interface ITaskRepository
    {
        public List<Task> GetAll();
    }
}