using API.Restaurantes.Domain.Models;
using API.Restaurantes.Domain.Services;
using API.Restaurantes.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Restaurantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : Controller
    {
        private readonly IRestaurantesService restaurantesServices;
        private readonly IMapper mapper;

        public RestaurantesController(IRestaurantesService restaurantesServices
            ,IMapper mapper)
        {
            this.restaurantesServices = restaurantesServices ??
                throw new ArgumentNullException(nameof(restaurantesServices));

            this.mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost, AllowAnonymous]
        [ProducesResponseType(typeof(Restaurante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GravarNovoRestauranteAsync([FromBody] RestaurantePostDto restaurantePostDto)
        { 
            var restaurante = mapper.Map<Restaurante>(restaurantePostDto);

            var restauranteGravado = await restaurantesServices.GravarRestauranteAsync(restaurante);

            return Ok(restauranteGravado);
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> ObterTodosRestaurantesAsync()
        {
            return Ok();
        }

        [HttpDelete, AllowAnonymous]
        public async Task<IActionResult> DeletarRestauranteAsync(Guid Id)
        {
            return Ok();
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> ObterRestaurantePorIdAsync(Guid Id)
        {
            return Ok();
        }


    }
}
