using OneLearn.Application.Transaction.VoiceTranslation.Interface;
using OneLearn.Domain.Transactions.VoiceTranslation;
using OneLearn.Infrastructure.Common;
using OneLearn.Infrastructure.Common.DBContexts;

namespace OneLearn.Infrastructure.Transactions.VoiceTranslation
{
    public class PassageRepository : GenericRepository<Passage>, IPassageRepository
    {
        public PassageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
