using AutoMapper;
using Google.Protobuf.Collections;
using Todo.Grpc.Helpers;
using Todo.Grpc.Models;

namespace Todo.Grpc.Mapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDto, TaskModel>().ReverseMap();
            CreateMap(typeof(IList<>), typeof(RepeatedField<>)).ConvertUsing(typeof(ListToRepeatedFieldTypeConverter<,>));
            CreateMap(typeof(RepeatedField<>), typeof(List<>)).ConvertUsing(typeof(RepeatedFieldToListTypeConverter<,>));
        }
    }
}