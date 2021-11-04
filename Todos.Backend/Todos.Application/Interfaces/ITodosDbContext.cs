using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todos.Domain;

namespace Todos.Application.Interfaces
{
    public interface ITodosDbContext
    {
        DbSet<Todo> Todos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
