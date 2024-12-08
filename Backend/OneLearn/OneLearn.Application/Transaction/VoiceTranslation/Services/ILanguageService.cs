

using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;

namespace OneLearn.Application.Transaction.VoiceTranslation.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<GetAllLanguageResponse>> GetAllLanguagesAsync();
    }
}
