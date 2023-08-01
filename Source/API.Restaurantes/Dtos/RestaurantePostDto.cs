namespace API.Restaurantes.Dtos
{
    public class RestaurantePostDto
    {
        public string? Nome { get; set; }
        public long Cnpj { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
    }
}
