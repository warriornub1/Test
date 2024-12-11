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
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "passageCacheKey";

        public PassageService(IPassageRepository passageRepository, ILanguageRepository languageRepository, IMapper mapper, IMemoryCache cache)
        {
            _languageRepository = languageRepository;
            _passageRepository = passageRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IEnumerable<GetAllPassageResponse>> GetAllPassageAsync()
        {
            // https://www.youtube.com/watch?v=2jj2wH60QuE
            // https://www.youtube.com/watch?v=KSRlVOgVxyI
            if (_cache.TryGetValue(cacheKey, out IEnumerable<GetAllPassageResponse> passageDTO))
            {
                // Log message
            }
            else
            {
                try
                {
                    await semaphore.WaitAsync();
                    if(_cache.TryGetValue(cacheKey, out passageDTO))
                    {
                        // Log "Employee found in cache"
                    }
                    else
                    {
                        var passage = await _passageRepository.GetAllAsync();
                        passageDTO = _mapper.Map<List<GetAllPassageResponse>>(passage);

                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(60)) // How long before the cache is remove from memory
                                .SetAbsoluteExpiration(TimeSpan.FromHours(1)) // It will expire regardless of whether anyone access
                                .SetPriority(CacheItemPriority.Normal); // Set priority when it will be remove from the cache

                        _cache.Set(cacheKey, passageDTO, cacheEntryOptions);
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }

            return passageDTO;
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
    }
}
