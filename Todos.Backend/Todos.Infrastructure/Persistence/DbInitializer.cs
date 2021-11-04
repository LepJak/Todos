using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Infrastructure.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TodosDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
