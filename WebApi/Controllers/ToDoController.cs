using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController: ControllerBase
    {
        private readonly ToDoDataContext _toDoDataContext;
        private readonly IMapper _mapper;

        public ToDoController(ToDoDataContext toDoDataContext, IMapper mapper)
        {
            _toDoDataContext = toDoDataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ToDoDto>> GetToDos()
        {
            var todos = await _toDoDataContext.Todo.ToListAsync();
            return _mapper.Map<List<ToDoDto>>(todos);
        }
    }
}
