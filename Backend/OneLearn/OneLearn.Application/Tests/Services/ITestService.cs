using Microsoft.AspNetCore.JsonPatch;
using OneLearn.Application.Tests.DTOs.Request;

namespace OneLearn.Application.Tests.Services
{
    public interface ITestService
    {
        Task UpdateTestAsync(UpdateMultipleTest request);
        Task UpdatePatchTestAsync(int id, JsonPatchDocument<UpdateTestDto> patch);
        Task UpdateTestMultipleAsync(List<UpdateMultipleTest> requests);
        Task BulkUpdatePatchAsync(List<UpdateMultipleTestPatch> updates);
    }
}
