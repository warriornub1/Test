using AutoMapper;
using OneLearn.Application.Tests.DTOs.Request;
using OneLearn.Application.VoiceTranslation.DTOs.Passage.Request;
using OneLearn.Domain.Test;
using OneLearn.Domain.VoiceTranslation;

namespace OneLearn.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<GetPassageRequest, Passage>().ReverseMap();
            CreateMap<UpdateTestDto, Test>().ReverseMap();
        }
    }
}
