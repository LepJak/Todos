using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Todos.Commands.CreateTodo;
using Todos.Application.Todos.Commands.UpdateTodo;
using Todos.Application.Todos.Queries.GetTodoDescription;
using Todos.Application.Todos.Queries.GetTodoList;
using Todos.Application.Todos.TodoCommandDto;
using Todos.Domain;

namespace Todos.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Todo, TodoDescriptionVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(dest => dest.ReminderDate, opt => opt.MapFrom(src => src.ReminderDate))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));

            CreateMap<Todo, TodoLookupDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(dest => dest.ReminderDate, opt => opt.MapFrom(src => src.ReminderDate));

            CreateMap<CreateTodoDto, CreateTodoCommand>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ReminderDate, opt => opt.MapFrom(src => src.ReminderDate));

            CreateMap<UpdateTodoDto, UpdateTodoCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(dest => dest.ReminderDate, opt => opt.MapFrom(src => src.ReminderDate))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
                
        }
    }
}
