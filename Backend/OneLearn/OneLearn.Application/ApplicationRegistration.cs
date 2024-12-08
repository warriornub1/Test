using OneLearn.Application.Transaction.VoiceTranslation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace OneLearn.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddAppplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped<ILanguageService, LanguageService>();
            return services;
        }
    }
}
