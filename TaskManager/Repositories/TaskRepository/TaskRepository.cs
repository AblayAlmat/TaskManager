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

        public void Add(Task task)
        {
            _context.Tasks.Add(task);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task GetById(string id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}