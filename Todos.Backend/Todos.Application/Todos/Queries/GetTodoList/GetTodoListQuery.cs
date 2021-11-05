using MediatR;
using System;

namespace Todos.Application.Todos.Queries.GetTodoList
{
    public class GetTodoListQuery : IRequest<TodoListVm>
    {
        public Guid UserId { get; set; }
    }
}
