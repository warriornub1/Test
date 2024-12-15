using Microsoft.Extensions.Caching.Distributed;
using OneLearn.Api.Extensions;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using OneLearn.Application.Transaction.VoiceTranslation.Interface;
using OneLearn.Domain.Transactions.VoiceTranslation;
using System.Text.Json;

namespace OneLearn.Application.Transaction.VoiceTranslation.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IRedisCacheService _redisCacheService;
        private const string LanguageCacheKey = "AllLanguagesCache";

        public LanguageService(ILanguageRepository languageRepository, IRedisCacheService redisCacheService)
        {
            _languageRepository = languageRepository;
            _redisCacheService = redisCacheService;
        }

        public async Task<IEnumerable<GetAllLanguageResponse>> GetAllLanguagesAsync()
        {
            // Check if data is already in the cache
            var cachedData = _redisCacheService.GetData<IEnumerable<GetAllLanguageResponse>>(LanguageCacheKey);
            if (LanguageCacheKey is not null)
            {
                return cachedData;
            }

            var dBRecord = await _languageRepository.GetAllAsync();
            _redisCacheService.SetData("AllLanguagesCache", dBRecord);
            return dBRecord.Select(x => new GetAllLanguageResponse
            {
                language = x.language,
                language_Code = x.language_Code,
            });
        }

        // Uncomment and modify if needed
        // public async Task CreateLanguage(CreateLanguageRequest request, string userId)
        // {
        //     await _languageRepository.CreateAsync(new Language
        //     {
        //         language = request.language,
        //         language_Code = request.language_Code,
        //         created_by = userId,
        //         created_on = DateTime.Now,
        //     });

        //     // Clear the cache since data has changed
        //     await _distributedCache.RemoveAsync(LanguageCacheKey);
        // }
    }
}
