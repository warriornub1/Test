using Microsoft.AspNetCore.Mvc;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.Services;

namespace OneLearn.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassageController : ControllerBase
    {
        private readonly IPassageService _passageService;
        public PassageController(IPassageService passageService)
        {
            _passageService = passageService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePassage([FromBody] CreatePassageRequest request)
        {
            await _passageService.CreatePassageAsync("asd", request);
            return Ok();
        }
    }
}
