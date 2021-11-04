using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todos.Application.Common.Exceptions;
using Todos.Application.Interfaces;
using Todos.Domain;

namespace Todos.Application.Todos.Commands.UpdateTodo
{
    class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
    {
        private readonly ITodosDbContext _dbContext;

        public UpdateTodoCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Todos.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundTodoException(nameof(Todo), request.Id, request.UserId);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.isCompleted = request.isCompleted;
            entity.ReminderDate = request.ReminderDate;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
