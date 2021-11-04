using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todos.Application.Interfaces;
using Todos.Domain;

namespace Todos.Application.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandHandler 
        : IRequestHandler<CreateTodoCommand, Guid>
    {
        private readonly ITodosDbContext _dbContext;

        public CreateTodoCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo
            {
                UserId = request.UserId,                
                Title = request.Title,
                Description = request.Description,
                CreationDate = DateTime.Now,
                EditDate = null,
                ReminderDate = request.ReminderDate,
                isCompleted = false,
                Id = Guid.NewGuid()
            };
            await _dbContext.Todos.AddAsync(todo, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return todo.Id;
        }
    }
}
