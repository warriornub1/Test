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
            CreateMap<RoleDTO, Role>().ReverseMap();

            // Config for different property names
            //CreateMap<StudentDTO, Student>().ForMember(x => x.StudentName, opt => opt.MapFrom(x => x.Name)).ReverseMap();

            // Config for ignore
            // CreateMap<StudentDTO, Student>().ReverseMap().ForMember(x => x.StudentName, opt => opt.Ignore());

            // Config for transforming some property
            // CreateMap<StudentDTO, Student>().ReverseMap().AddTransform<string>(n => string.IsNullOrEmpty(n) ? "no address provided");

            //CreateMap<StudentDTO, Student>().ReverseMap()
            //    .ForMember(n => n.Address, opt => opt.MapFrom(n => string.IsNullOrEmpty(n.Address)? "No address found" : n.Address));

        }
    }
}
