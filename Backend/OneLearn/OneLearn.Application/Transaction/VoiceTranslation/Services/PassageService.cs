using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.Interface;
using OneLearn.Domain.Transactions.VoiceTranslation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneLearn.Application.Transaction.VoiceTranslation.Services
{
    public class PassageService : IPassageService
    {
        private readonly IPassageRepository _passageRepository;
        private readonly ILanguageRepository _languageRepository;
        public PassageService(IPassageRepository passageRepository, ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
            _passageRepository = passageRepository;
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
