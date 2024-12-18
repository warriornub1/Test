using AutoMapper;
using OneLearn.Application.Tests.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using OneLearn.Domain.Test;
using OneLearn.Domain.Transactions.VoiceTranslation;

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
