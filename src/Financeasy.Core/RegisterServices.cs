using Microsoft.Extensions.DependencyInjection;

namespace Financeasy.Core
{
    public static class RegisterServices
    {
        public static IServiceCollection AddFinanceasyCore(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}