using FluentValidation;
using System;

namespace Todos.Application.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(createTodoCommand =>
                createTodoCommand.Title).NotEmpty().MaximumLength(100);

            RuleFor(createTodoCommand =>
                createTodoCommand.UserId).NotEqual(Guid.Empty);

            RuleFor(createTodoCommand =>
                createTodoCommand.Description).MaximumLength(500);

        }
    }
}
