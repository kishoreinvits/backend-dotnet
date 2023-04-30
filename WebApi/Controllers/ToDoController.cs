using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController: ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public ToDoController(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ToDoDto>> GetToDos()
        {
            var todos = await _todoRepository.ListAsync();
            return _mapper.Map<List<ToDoDto>>(todos);
        }
    }
}
