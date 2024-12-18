using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using OneLearn.Application.Transaction.VoiceTranslation.Interface;
using OneLearn.Domain.Transactions.VoiceTranslation;

namespace OneLearn.Application.Transaction.VoiceTranslation.Services
{
    public class PassageService : IPassageService
    {
        private readonly IPassageRepository _passageRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public PassageService(IPassageRepository passageRepository, ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _passageRepository = passageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllPassageResponse>> GetAllPassageAsync()
        {
            // https://www.youtube.com/watch?v=2jj2wH60QuE
            // https://www.youtube.com/watch?v=KSRlVOgVxyI
            var passage = await _passageRepository.GetAllAsync();
            var response = passage.Select(x => new GetAllPassageResponse
            {
                langauge_id = x.langauge_id,
                title = x.passage.Length >= 5 ? x.passage.Substring(0, 5) : x.passage,
                passage = x.passage
            });
                       
            return response;
        }

        public async Task CreatePassageAsync(string userId, CreatePassageRequest request)
        {
            // throw exception
            await _languageRepository.GetByIdAsync(x => x.id == request.language_id);

            await _passageRepository.CreateAsync(new Passage
            {
                langauge_id = request.language_id,
                passage = request.passage,
                created_by = userId,
                created_on = DateTime.Now
            });

        }

        public async Task<GetPassageRequest> GetPassageByIdAsync(int id)
        {
            var passagedB = await _passageRepository.GetByIdAsync(x => x.id == id);
            return _mapper.Map<GetPassageRequest>(passagedB);
        }

    }
}
