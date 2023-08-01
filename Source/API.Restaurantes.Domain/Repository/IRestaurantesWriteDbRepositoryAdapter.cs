using API.Restaurantes.Domain.Models;

namespace API.Restaurantes.Domain.Repository
{
    public interface IRestaurantesWriteDbRepositoryAdapter
    {
        Task<int> GravarRestauranteAsync(Restaurante restaurante);
    }
}
