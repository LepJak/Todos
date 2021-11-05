using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Todos.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Todos.Application.Todos.Queries.GetTodoList
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, TodoListVm>
    {
        public GetTodoListQueryHandler(ITodosDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);


        private readonly ITodosDbContext _dbContext;
        private readonly IMapper _mapper;

        public async Task<TodoListVm> Handle(GetTodoListQuery request,
            CancellationToken cancellationToken)
        {
            var todos = await _dbContext.Todos
                .Where(todo => todo.UserId == request.UserId)
                .ProjectTo<TodoLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new TodoListVm { Todos = todos };
        }
    }
}
