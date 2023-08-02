using API.Restaurantes.Domain.Models;
using API.Restaurantes.Domain.Repository;
using API.Restaurantes.Domain.Services;

namespace API.Restaurantes.Application.Services
{
    public class RestaurantesService : IRestaurantesService
    {
        private readonly IRestaurantesWriteDbRepositoryAdapter restaurantesWriteDbRepositoryAdapter;
        private readonly IRestaurantesReadDbRepositoryAdapter restaurantesReadDbRepositoryAdapter;

        public RestaurantesService(IRestaurantesWriteDbRepositoryAdapter restaurantesWriteDbRepositoryAdapter,
            IRestaurantesReadDbRepositoryAdapter restaurantesReadDbRepositoryAdapter)
        {
            this.restaurantesWriteDbRepositoryAdapter = restaurantesWriteDbRepositoryAdapter ??
                throw new ArgumentException(nameof(restaurantesWriteDbRepositoryAdapter));

            this.restaurantesReadDbRepositoryAdapter = restaurantesReadDbRepositoryAdapter ??
                throw new ArgumentException(nameof(restaurantesReadDbRepositoryAdapter));
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

        public async Task<Restaurante> ObterRestaurantePorIdAsync(int id)
        {
            var restaurante = await restaurantesReadDbRepositoryAdapter.ObterRestaurantePorIdAsync(id);

            return restaurante;
        }

        public async Task<IEnumerable<Restaurante>> ObterTodosRestaurantesAsync()
        {
            var listaRestaurantes = await restaurantesReadDbRepositoryAdapter.ObterTodosRestaurantesAsync();

            return listaRestaurantes;
        }
    }
}
