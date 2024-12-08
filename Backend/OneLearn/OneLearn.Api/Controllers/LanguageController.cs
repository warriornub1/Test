using Microsoft.AspNetCore.Mvc;
using OneLearn.Application.Transaction.VoiceTranslation.Services;

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
            var languages = await _languageService.GetAllLanguagesAsync();
            return Ok(languages);
        }
    }
}
