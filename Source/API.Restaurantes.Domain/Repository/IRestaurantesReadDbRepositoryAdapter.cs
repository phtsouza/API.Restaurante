using API.Restaurantes.Domain.Models;

namespace API.Restaurantes.Domain.Repository
{
    public interface IRestaurantesReadDbRepositoryAdapter
    {
        Task<IEnumerable<Restaurante>> ObterTodosRestaurantesAsync();

        Task<Restaurante> ObterRestaurantePorIdAsync(int id);
    }
}
