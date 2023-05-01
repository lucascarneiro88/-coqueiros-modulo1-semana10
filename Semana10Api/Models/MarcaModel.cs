using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semana10Api.Models
{
    
        [Table("MARCAS")]
        public class MarcaModel
        {

        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
                               
        }
}
