using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Todos.Queries.GetTodoDescription
{
    public class GetTodoDescriptionQuery : IRequest<TodoDescriptionVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
