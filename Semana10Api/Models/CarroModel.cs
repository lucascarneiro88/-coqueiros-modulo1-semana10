using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Semana10Api.Models;

namespace Semana10Api.Models
{
        
        [Table("CARROS")]
        public class CarroModel
        {
        [Key]
        public int Id { get; set; }  //Id Int PK
        [Required]
        public string Nome{ get; set; }//Nome String NOT NULL

        [Key]        
        [ForeignKey("MarcaModel")]//Essa Propriedade é o que será relacionamento com a tabela Marcas no banco de dados
        public List<MarcaModel> Marcas { get; set; } //Marcas do Tipo List<MarcaModel>(FK)
        public DateTime? DataLocacao { get; set; }//DataLocacao Datetime NULL‌
       
        }
}