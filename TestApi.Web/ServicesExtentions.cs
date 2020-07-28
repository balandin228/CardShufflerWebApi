using Microsoft.Extensions.DependencyInjection;
using TestApi.Core.Infrastructure.Repositories;

namespace TestApi.Web
{
    public static class ServicesExtentions
    {
        public static void RegisterAllRepository(this IServiceCollection services)
        {
            services.AddTransient<IDeckRepository, DeckRepository>();
            services.AddTransient<ICardInDeckRepository, CardInDeckRepository>();
            services.AddTransient<ICardRepository, CardRepository>();
        }
    }
}