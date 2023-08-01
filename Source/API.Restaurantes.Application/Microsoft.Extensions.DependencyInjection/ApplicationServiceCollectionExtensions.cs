using API.Restaurantes.Application.Services;
using API.Restaurantes.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace API.Restaurantes.Application.Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            ApplicationConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            //if (configuration is null)
            //{
            //    throw new ArgumentNullException(nameof(configuration));
            //}

            //services.AddSingleton(configuration);

            services.AddScoped<IRestaurantesService, RestaurantesService>();

            return services;
        }
    }
}
