using AutoMapper;
using Domain;
using REST_Service.Model;

namespace REST_Service.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<StudentModel, Student>();
            Mapper.CreateMap<Student, StudentModel>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}