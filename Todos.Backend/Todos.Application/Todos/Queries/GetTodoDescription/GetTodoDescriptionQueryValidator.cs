using System;
using FluentValidation;

namespace Todos.Application.Todos.Queries.GetTodoDescription
{
    public class GetTodoDescriptionQueryValidator : AbstractValidator<GetTodoDescriptionQuery>
    {
        public GetTodoDescriptionQueryValidator()
        {
            RuleFor(getTodoDescriptionQuery =>
                getTodoDescriptionQuery.Id).NotEqual(Guid.Empty);

            RuleFor(getTodoDescriptionQuery =>
                getTodoDescriptionQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
