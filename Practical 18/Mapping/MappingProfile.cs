using Practical_18.Models;
using Practical_18.ViewModels;
using AutoMapper;


namespace Practical_18.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentViewModel, Student>();
            CreateMap<Student, StudentViewModel>();
        }
    }
}
