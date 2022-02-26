using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models.DbMapConfigurations;

namespace TaskManager.Models.DbContext
{
    public class TaskManagerContext : IdentityDbContext<User>
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new TaskDbMap());
        }
    }
}