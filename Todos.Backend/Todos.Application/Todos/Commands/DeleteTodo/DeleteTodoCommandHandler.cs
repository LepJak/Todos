using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todos.Application.Common.Exceptions;
using Todos.Application.Interfaces;
using Todos.Domain;

namespace Todos.Application.Todos.Commands.DeleteTodo
{
    class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly ITodosDbContext _dbContext;

        public DeleteTodoCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Todos
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundTodoException(nameof(Todo), request.Id, request.UserId);
            }

            _dbContext.Todos.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
