using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;
using TaskManager.Models.DbContext;

namespace TaskManager.Repositories.TaskRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _context;

        public TaskRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public List<Task> GetAll()
        {
            return _context.Tasks.ToList();
        }
    }
}