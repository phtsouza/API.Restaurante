using API.Restaurantes.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace API.Restaurantes.DbRepository.Adapter.Microsoft.Extensions.DependencyInjection
{
    public static class DbRepositoryAdapterServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddDbRepositoryAdapter(
            this IServiceCollection services,
            DbRepositoryAdapterConfiguration dbRepositoryAdapterConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (dbRepositoryAdapterConfiguration is null)
            {
                throw new ArgumentNullException(nameof(dbRepositoryAdapterConfiguration));
            }

            services.AddSingleton(dbRepositoryAdapterConfiguration);

            services.AddScoped<IRestaurantesWriteDbRepositoryAdapter, RestaurantesDbRepositoryAdapter>();
            services.AddScoped<IRestaurantesReadDbRepositoryAdapter, RestaurantesDbRepositoryAdapter>();

            services.AddScoped<IDbConnection>(d =>
            {
                return new SqlConnection(dbRepositoryAdapterConfiguration.SqlConnectionString);
            });

            return services;
        }
    }
}
