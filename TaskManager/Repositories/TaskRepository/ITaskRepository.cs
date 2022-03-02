using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.Repositories.TaskRepository
{
    public interface ITaskRepository : IRepository<Task>
    {
        public List<Task> GetAll();
    }
}