using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoCommandValidator()
        {
            RuleFor(deleteTodoCommand =>
                deleteTodoCommand.UserId).NotEqual(Guid.Empty);

            RuleFor(deleteTodoCommand =>
                deleteTodoCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
