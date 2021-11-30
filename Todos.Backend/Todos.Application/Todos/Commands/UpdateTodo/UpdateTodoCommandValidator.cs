using FluentValidation;
using System;

namespace Todos.Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidator()
        {
            RuleFor(updateTodoCommand =>
                updateTodoCommand.Title).NotEmpty().MaximumLength(100);

            RuleFor(updateTodoCommand =>
                updateTodoCommand.UserId).NotEqual(Guid.Empty);

            RuleFor(updateTodoCommand =>
                updateTodoCommand.Id).NotEqual(Guid.Empty);

            RuleFor(createTodoCommand =>
                createTodoCommand.Description).MaximumLength(500);
        }
    }
}
