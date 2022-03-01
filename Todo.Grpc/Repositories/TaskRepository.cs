using Todo.Grpc.Models;

namespace Todo.Grpc.Repositories
{
    public interface ITaskRepository
    {
        Task<IList<TaskDto>> GetAll();
    }

    public class TaskRepository : ITaskRepository
    {
        public async Task<IList<TaskDto>> GetAll()
        {
            IList<TaskDto> list = new List<TaskDto>
            {
                new TaskDto
                {
                    Id = 1,
                    Description = "Teste 1",
                    Done = false
                },

                new TaskDto
                {
                    Id = 2,
                    Description = "Teste 2",
                    Done = false
                },

                new TaskDto
                {
                    Id = 3,
                    Description = "Teste 3",
                    Done = true
                }
            };

            return list;
        }
    }
}