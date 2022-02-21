using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models.DbContext
{
    public class TaskManagerContext : IdentityDbContext<User>
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
            
        }
    }
}