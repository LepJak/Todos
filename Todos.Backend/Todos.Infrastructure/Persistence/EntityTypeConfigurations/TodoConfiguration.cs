using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todos.Domain;

namespace Todos.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(todo => todo.Id);
            builder.HasIndex(todo => todo.Id).IsUnique();
            builder.Property(todo => todo.Title).HasMaxLength(100);
            builder.Property(todo => todo.Description).HasMaxLength(500);
        }
    }
}
