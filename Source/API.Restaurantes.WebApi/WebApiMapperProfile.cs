using API.Restaurantes.Domain.Models;
using API.Restaurantes.Dtos;
using AutoMapper;

namespace API.Restaurantes
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<RestaurantePostDto, Restaurante>();
            CreateMap<Restaurante, RestauranteGetResult>();
        }
    }
}
