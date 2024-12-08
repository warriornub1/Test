using OneLearn.Application.Transaction.VoiceTranslation.Interface;
using OneLearn.Domain.Transactions.VoiceTranslation;
using OneLearn.Infrastructure.Common;
using OneLearn.Infrastructure.Common.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneLearn.Infrastructure.Transactions.VoiceTranslation
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            
        }
    }
}
