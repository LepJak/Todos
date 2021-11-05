using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Todos.Application.Todos.Commands.CreateTodo;
using Todos.Application.Todos.Queries.GetTodoDescription;
using Todos.Application.Todos.Queries.GetTodoList;
using Todos.Application.Todos.TodoCommandDto;
using Todos.Application.Todos.Commands.UpdateTodo;
using Todos.Application.Todos.Commands.DeleteTodo;

namespace Todos.WebApi.Controllers
{
    public class TodoController : BaseController
    {
        private readonly IMapper _mapper;

        public TodoController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<TodoListVm>> GetAll()
        {
            var query = new GetTodoListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDescriptionVm>> Get(Guid id)
        {
            var query = new GetTodoDescriptionQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoDto createTodoDto)
        {
            var command = _mapper.Map<CreateTodoCommand>(createTodoDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTodoDto updateTodoDto)
        {
            var command = _mapper.Map<UpdateTodoCommand>(updateTodoDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTodoCommand
            {
                Id = id,
                UserId = UserId
            };
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return NoContent();
        }
    }
}
