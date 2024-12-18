using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneLearn.Application.Transaction.VoiceTranslation.Services
{
    public interface IPassageService
    {
        Task<IEnumerable<GetAllPassageResponse>> GetAllPassageAsync();

        Task CreatePassageAsync(string userId, CreatePassageRequest request);
        Task<GetPassageRequest> GetPassageByIdAsync(int id);
    }
}
