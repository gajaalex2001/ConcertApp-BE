using ConcertApp.Data;

namespace ConcertApp.API.DependencyRegistration
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ConcertAppContext, ConcertAppContext>();
        }
    }
}
