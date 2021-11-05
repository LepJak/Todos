using MediatR;
using System;

namespace Todos.Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? ReminderDate { get; set; }
        
    }
}
