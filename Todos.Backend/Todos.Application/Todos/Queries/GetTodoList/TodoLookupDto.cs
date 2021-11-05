using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Todos.Queries.GetTodoList
{
    public class TodoLookupDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
