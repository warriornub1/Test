using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Model;

namespace CollegeApp.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            //CreateMap<Student, StudentDTO>();
            //CreateMap<StudentDTO, Student>();

            // Shortcut

            // Config for different property names
            CreateMap<StudentDTO, Student>().ReverseMap();
            //CreateMap<StudentDTO, Student>().ForMember(x => x.StudentName, opt => opt.MapFrom(x => x.Name)).ReverseMap();
            
        }
    }
}
