using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.Models.DbMapConfigurations
{
    public class TaskDbMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd().HasMaxLength(36);
            builder.Property(t => t.Name).HasMaxLength(64);
            builder.Property(t => t.Description).HasMaxLength(1024);
        }
    }
}