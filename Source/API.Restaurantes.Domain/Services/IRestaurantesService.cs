﻿using API.Restaurantes.Domain.Models;

namespace API.Restaurantes.Domain.Services
{
    public interface IRestaurantesService
    {
        Task<Restaurante> GravarRestauranteAsync(Restaurante restaurante);

        Task<IEnumerable<Restaurante>> ObterTodosRestaurantesAsync();

        Task<Restaurante> ObterRestaurantePorIdAsync(int id);
    }
}
