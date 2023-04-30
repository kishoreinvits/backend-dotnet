using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Mapper;

public class ToDoMapperProfile : Profile
{
    public ToDoMapperProfile()
    {
        CreateMap<ToDo, ToDoDto>();
        CreateMap<ToDoDto, ToDo>();
        CreateMap<ToDoState, ToDoStateDto>();
        CreateMap<ToDoStateDto, ToDoState>();
    }
}