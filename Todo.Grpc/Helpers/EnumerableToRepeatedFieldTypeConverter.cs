using AutoMapper;
using Google.Protobuf.Collections;

namespace Todo.Grpc.Helpers
{
    public class ListToRepeatedFieldTypeConverter<TITemSource, TITemDest> : ITypeConverter<IList<TITemSource>, RepeatedField<TITemDest>>
    {
        public RepeatedField<TITemDest> Convert(IList<TITemSource> source, RepeatedField<TITemDest> destination, ResolutionContext context)
        {
            destination ??= new RepeatedField<TITemDest>();
            foreach (var item in source)
            {
                destination.Add(context.Mapper.Map<TITemDest>(item));
            }
            return destination;
        }
    }

    public class RepeatedFieldToListTypeConverter<TITemSource, TITemDest> : ITypeConverter<RepeatedField<TITemSource>, List<TITemDest>>
    {
        public List<TITemDest> Convert(RepeatedField<TITemSource> source, List<TITemDest> destination, ResolutionContext context)
        {
            destination ??= new List<TITemDest>();
            foreach (var item in source)
            {
                destination.Add(context.Mapper.Map<TITemDest>(item));
            }
            return destination;
        }
    }
}