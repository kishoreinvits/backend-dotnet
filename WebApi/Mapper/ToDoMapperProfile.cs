using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Mapper;

public class ToDoMapperProfile : Profile
{
    public ToDoMapperProfile()
    {
        CreateMap<Todo, ToDoDto>();
        CreateMap<ToDoDto, Todo>();
        CreateMap<ToDoState, ToDoStateDto>();
        CreateMap<ToDoStateDto, ToDoState>();
    }
}