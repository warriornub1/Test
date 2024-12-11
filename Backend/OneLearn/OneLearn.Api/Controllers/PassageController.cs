using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using OneLearn.Application.Transaction.VoiceTranslation.Services;

namespace OneLearn.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PassageController : ControllerBase
    {
        private readonly IPassageService _passageService;
        public PassageController(IPassageService passageService, IMemoryCache cache)
        {
            _passageService = passageService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllPassage()
        {
            var result = await _passageService.GetAllPassageAsync();
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> CreatePassage([FromBody] CreatePassageRequest request)
        {
            await _passageService.CreatePassageAsync("asd", request);
            return Ok();
        }
    }
}
