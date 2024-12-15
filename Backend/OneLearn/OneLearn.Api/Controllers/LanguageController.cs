using Microsoft.AspNetCore.Mvc;
using OneLearn.Application.Transaction.VoiceTranslation.Services;
using Microsoft.Extensions.Caching.Distributed;
using OneLearn.Api.Extensions;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using OneLearn.Domain.Transactions.VoiceTranslation;

namespace OneLearn.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
           _languageService = languageService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var language = await _languageService.GetAllLanguagesAsync();
            return Ok(language);
        }
    }
}
