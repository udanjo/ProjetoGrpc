namespace Todo.Grpc.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        
        public string Description { get; set; }

        public bool Done { get; set; }
    }
}
