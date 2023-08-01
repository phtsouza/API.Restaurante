using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Restaurantes.Domain.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public long Cnpj { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
    }
}
