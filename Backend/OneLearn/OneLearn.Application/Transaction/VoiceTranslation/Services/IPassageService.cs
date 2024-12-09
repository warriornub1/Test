using OneLearn.Application.Transaction.VoiceTranslation.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneLearn.Application.Transaction.VoiceTranslation.Services
{
    public interface IPassageService
    {
        Task CreatePassageAsync(string userId, CreatePassageRequest request);
    }
}
