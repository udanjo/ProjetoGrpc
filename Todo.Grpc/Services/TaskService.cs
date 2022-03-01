using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Todo.Grpc.Repositories;

namespace Todo.Grpc.Services
{
    public class TaskService : TaskProtoService.TaskProtoServiceBase
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<TaskList> GetAll(GetAllTaskRequest request, ServerCallContext context)
        {
            var list = await _repository.GetAll();
           
            var repeated = _mapper.Map<RepeatedField<TaskModel>>(list);
            var result = new TaskList();
            result.Task.AddRange(repeated);

            return result;
        }

        public override async Task<TaskModel> GetById(GetbyIdTaskRequest request, ServerCallContext context)
        {
            var list = await _repository.GetAll();
            var listFilter = list.Where(x => x.Id == request.Id).FirstOrDefault();

            var result = _mapper.Map<TaskModel>(listFilter);

            return result;
        }
    }
}