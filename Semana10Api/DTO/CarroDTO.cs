using Semana10Api.DTO;
using Semana10Api.Models;
using System;

namespace Semana10Api.DTO
{
    public class CarroDTO
    {
        public int Id { get; set; }     
        public string Nome { get; set; }
        public List<MarcaModel> Marcas { get; set; }
        public DateTime? DataLocacao { get; set; }
    }

}
