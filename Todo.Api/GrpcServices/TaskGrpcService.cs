using Todo.Grpc;

namespace Todo.Api.GrpcServices
{
    public class TaskGrpcService
    {
        private readonly TaskProtoService.TaskProtoServiceClient _taskProtoServiceClient;

        public TaskGrpcService(TaskProtoService.TaskProtoServiceClient taskProtoServiceClient)
        {
            _taskProtoServiceClient = taskProtoServiceClient;
        }

        public async Task<TaskModel> GetTask(int id)
        {
            var taskrequest = new GetbyIdTaskRequest { Id = id };

            var result = await _taskProtoServiceClient.GetByIdAsync(taskrequest);

            return result;
        }

        public async Task<TaskList> GetAll()
        {
            var taskrequest = new GetAllTaskRequest();

            return await _taskProtoServiceClient.GetAllAsync(taskrequest);
        }
    }
}
