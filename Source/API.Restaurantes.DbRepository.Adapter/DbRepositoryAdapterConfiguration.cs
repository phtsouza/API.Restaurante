using System.ComponentModel.DataAnnotations;

namespace API.Restaurantes.DbRepository.Adapter
{
    public class DbRepositoryAdapterConfiguration
    {
        [Required]
        public string SqlConnectionString { get; set; }
    }
}
