using Microsoft.Extensions.DependencyInjection;
using OneLearn.Application.Common;
using OneLearn.Application.Transaction.VoiceTranslation.Interface;
using OneLearn.Infrastructure.Common;
using OneLearn.Infrastructure.Transactions.VoiceTranslation;

namespace OneLearn.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILanguageRepository, LanguageRepository>();

            return services;
        }
    }
}
