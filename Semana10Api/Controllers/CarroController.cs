using Locacao.Context;
using Microsoft.AspNetCore.Mvc;
using Semana10Api.Models;


namespace Semana10Api.DTO
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly LocacaoContext locacaoContext;

        //Construtor com parametro (Injetado)
        public CarroController(LocacaoContext locacaoContext)
        {
            this.locacaoContext = locacaoContext;
        }

        [HttpPost]
        public ActionResult Inserir([FromBody] CarroGetDTO carroGetDTO)
        {
            if (carroGetDTO == null)
            {
                return BadRequest("Precisa inserir dados.");
            }
            else
            {
                if (carroGetDTO.Id != 0)
                {
                    return BadRequest("Id deve ser igual a zero(0).");
                }
                else
                {
                    foreach (var item in locacaoContext.Marca)
                    {
                        if (item.Id == carroGetDTO.IdMarca)
                        {
                            CarroModel carroModel = new CarroModel();
                            {
                                carroModel.Id = carroGetDTO.Id;
                                carroModel.Nome = carroGetDTO.DescricaoCarro;
                                carroModel.DataLocacao = carroGetDTO.DataLocacao;
                                carroModel.Id = carroGetDTO.IdMarca;
                            }
                            locacaoContext.Carro.Add(carroModel);
                            locacaoContext.SaveChanges();
                            return Ok("Salvo com sucesso.");
                        }
                        else { return BadRequest("Id de marca não encontrado."); }
                    }
                }


            }
            return Ok();
        }

        [HttpPut]
        public ActionResult<CarroDTO> Put([FromBody] CarroDTO carroDTO)
        {


            var carroModel = new CarroModel();
            carroModel.Id = carroDTO.Id;
            carroModel.Nome = carroDTO.Nome;

            locacaoContext.Carro.Attach(carroModel);
            locacaoContext.SaveChanges();

            return Ok(carroDTO);
        }

        [HttpGet]
        public ActionResult<List<CarroDTO>> Get()
        {
            var listaMarcaModel = locacaoContext.Marca;
            List<CarroDTO> listaGetDto = new List<CarroDTO>();

            foreach (var item in listaMarcaModel)
            {
                var carroDTO = new CarroDTO();
                carroDTO.Id = item.Id;
                carroDTO.Nome = item.Nome;

                listaGetDto.Add(carroDTO);
            }

            return Ok(listaGetDto);

        }

        [HttpGet("{id}")]
        public ActionResult<CarroDTO> Get([FromRoute] int id)
        {
            //Buscar o registro no banco de dados por Id
            var carroModel = locacaoContext.Carro.Find(id);
            // var carroModel = bancoDadosContext.Carro.Where(w => w.Id == id).FirstOrDefault();

            if (carroModel == null)
            {
                return NotFound("Dados não encontrados ");
            }

            CarroDTO carroDTO = new CarroDTO();
            carroDTO.Id = carroModel.Id;
            carroDTO.Nome = carroModel.Nome;

            return Ok(carroDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Verificar se existe registro no banco de dados
            var carroModel = locacaoContext.Carro.Find(id);

            //Verificar se o registro est� diferente de null
            if (carroModel != null)
            {
                //Deletar o regitro no banco de dados

                locacaoContext.Carro.Remove(carroModel);
                locacaoContext.SaveChanges();

                return Ok();

            }
            else
            {
                //se for null retorno um request de erro
                return NotFound("Id não existente ");
            }

        }

    }


}