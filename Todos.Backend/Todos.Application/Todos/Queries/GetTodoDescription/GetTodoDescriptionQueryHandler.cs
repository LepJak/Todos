using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Todos.Application.Common.Exceptions;
using Todos.Application.Interfaces;
using Todos.Domain;

namespace Todos.Application.Todos.Queries.GetTodoDescription
{
    public class GetTodoDescriptionQueryHandler : IRequestHandler<GetTodoDescriptionQuery, TodoDescriptionVm>
    {
        public GetTodoDescriptionQueryHandler(ITodosDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);


        private readonly ITodosDbContext _dbContext;
        private readonly IMapper _mapper;
        public async Task<TodoDescriptionVm> Handle(GetTodoDescriptionQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Todos
                .FirstOrDefaultAsync(todo =>
                todo.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundTodoException(nameof(Todo), request.Id, request.UserId);
            }

            return _mapper.Map<TodoDescriptionVm>(entity);
        }
    }
}
