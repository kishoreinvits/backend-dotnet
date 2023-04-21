using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController: ControllerBase
    {
        private readonly IEnumerable<ToDoDto> _toDos;

        public ToDoController()
        {
            _toDos = new List<ToDoDto>
            {
                new()
                {
                    Id = 1,
                    Description = "Add persistence with database",
                    State = ToDoState.Pending
                },
                new()
                {
                    Id = 2,
                    Description = "Add API version",
                    State = ToDoState.Pending
                },
                new()
                {
                    Id = 3,
                    Description = "Create typed http client",
                    State = ToDoState.Pending
                }
            };
        }

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<ToDoDto>>> GetToDos()
        public IEnumerable<ToDoDto> GetToDos()
        {
            return _toDos;
        }
    }
}
