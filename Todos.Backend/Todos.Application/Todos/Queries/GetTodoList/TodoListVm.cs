using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Todos.Queries.GetTodoList
{
    public class TodoListVm
    {
        public IList<TodoLookupDto> Todos { get; set; }
    }
}
