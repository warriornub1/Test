using Microsoft.Extensions.Caching.Distributed;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using OneLearn.Application.Transaction.VoiceTranslation.Interface;
using OneLearn.Domain.Transactions.VoiceTranslation;

namespace OneLearn.Application.Transaction.VoiceTranslation.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IDistributedCache _distributedCache;

        public LanguageService(ILanguageRepository languageRepository, IDistributedCache distributedCache)
        {
            _languageRepository = languageRepository;
            _distributedCache = distributedCache;
        }

        public async Task<IEnumerable<GetAllLanguageResponse>> GetAllLanguagesAsync()
        {
            _distributedCache.Get();
            return (await _languageRepository.GetAllAsync()).Select(x => new GetAllLanguageResponse
            {
                language = x.language,
                language_Code = x.language_Code
            });
        }

        //public async Task CreateLanguage(CreateLanguageRequest request, string userId)
        //{
        //    await _languageRepository.CreateAsync(new Language
        //    {
        //        language = request.language,
        //        language_Code = request.language_Code,
        //        created_by = userId,
        //        created_on = DateTime.Now,
        //    });
        //}
    }
}
