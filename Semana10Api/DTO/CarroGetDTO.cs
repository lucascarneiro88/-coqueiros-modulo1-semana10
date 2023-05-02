namespace Semana10Api.DTO
{
  
        public class CarroMarcaGetDTO
        {
            public int Id { get; set; }
            public string DescricaoCarro { get; set; }
            public int IdMarca { get; set; }
            public DateTime DataLocacao { get; set; }
            public List<MarcaDTO> ListaMarcaDTO { get; set; }
        }
    
}
