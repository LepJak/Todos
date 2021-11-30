using System;
using FluentValidation;

namespace Todos.Application.Todos.Queries.GetTodoList
{
    public class GetTodoListQueryValidator : AbstractValidator<GetTodoListQuery>
    {
        public GetTodoListQueryValidator()
        {
            RuleFor(getTodoListQueryValidator => getTodoListQueryValidator.UserId).NotEqual(Guid.Empty);
        }
    }
}
