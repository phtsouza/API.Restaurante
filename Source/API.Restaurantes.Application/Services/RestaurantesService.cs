using API.Restaurantes.Domain.Models;
using API.Restaurantes.Domain.Repository;
using API.Restaurantes.Domain.Services;

namespace API.Restaurantes.Application.Services
{
    public class RestaurantesService : IRestaurantesService
    {
        private readonly IRestaurantesWriteDbRepositoryAdapter restaurantesWriteDbRepositoryAdapter;

        public RestaurantesService(IRestaurantesWriteDbRepositoryAdapter restaurantesWriteDbRepositoryAdapter)
        {
            this.restaurantesWriteDbRepositoryAdapter = restaurantesWriteDbRepositoryAdapter ??
                throw new ArgumentException(nameof(restaurantesWriteDbRepositoryAdapter));
        }


        public async Task<Restaurante> GravarRestauranteAsync(Restaurante restaurante)
        {
            try
            {
                restaurante.Id = await restaurantesWriteDbRepositoryAdapter.GravarRestauranteAsync(restaurante);
            }
            catch 
            {
                throw new Exception();
            }
           
            return restaurante;
        }
    }
}
