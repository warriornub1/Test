using Azure.Core;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OneLearn.Application.Tests.DTOs.Request;
using OneLearn.Application.Tests.Services;

namespace OneLearn.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTest(int id, [FromBody] UpdateTestDto request)
        {
            await _testService.UpdateTestAsync(id, request);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateTestPatch(int id, [FromBody] JsonPatchDocument<UpdateTestDto> patchDocument)
        {
            await _testService.UpdatePatchTestAsync(id, patchDocument);
            return Ok();
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateMultiple()
        //{

        //}

        //[HttpPatch]
        //public async Task<IActionResult> UpdateMultiplePatch()
        //{

        //}
    }
}
