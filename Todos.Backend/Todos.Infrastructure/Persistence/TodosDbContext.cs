using Microsoft.EntityFrameworkCore;
using Todos.Application.Interfaces;
using Todos.Domain;
using Todos.Infrastructure.Persistence.EntityTypeConfigurations;

namespace Todos.Infrastructure.Persistence
{
    public class TodosDbContext : DbContext, ITodosDbContext
    {
        public TodosDbContext(DbContextOptions<TodosDbContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TodoConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
