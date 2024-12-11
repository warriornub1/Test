using AutoMapper;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using OneLearn.Domain.Transactions.VoiceTranslation;

namespace OneLearn.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<GetAllPassageResponse, Passage>().ReverseMap();
        }
    }
}
