using Microsoft.AspNetCore.Mvc;
using Todo.Api.GrpcServices;
using Todo.Grpc;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskGrpcService _service;

        public TaskController(TaskGrpcService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<TaskModel?> GetbyId(int id)
        {
            var result = await _service.GetTask(id).ConfigureAwait(false);

            return result;
        }

        [HttpGet()]
        public async Task<TaskList> GetAll()
        {
            var result = await _service.GetAll();

            return result;
        }
    }
}