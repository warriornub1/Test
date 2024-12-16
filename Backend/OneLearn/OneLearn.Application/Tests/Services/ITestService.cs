using Microsoft.AspNetCore.JsonPatch;
using OneLearn.Application.Tests.DTOs.Request;

namespace OneLearn.Application.Tests.Services
{
    public interface ITestService
    {
        Task UpdateTestAsync(int id, UpdateTestDto request);
        Task UpdatePatchTestAsync(int id, JsonPatchDocument<UpdateTestDto> patch);
    }
}
