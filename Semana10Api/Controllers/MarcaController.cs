using Locacao.Context;
using Microsoft.AspNetCore.Mvc;
using Semana10Api.DTO;
using Semana10Api.Models;

namespace Semana10Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class MarcaController : ControllerBase
        {
            private readonly LocacaoContext locacaoContext;

            //Construtor com parametro (Injetado)
            public MarcaController(LocacaoContext locacaoContext)
            {
                this.locacaoContext = locacaoContext;
            }

            [HttpPost]
            public ActionResult<MarcaDTO> Post([FromBody] MarcaDTO marcaDTO)
            {

                var marcaModel = new MarcaModel();

                {
                    marcaModel.Id = marcaDTO.Id;
                    marcaModel.Nome = marcaDTO.Nome;

                }

                locacaoContext.Marca.Add(marcaModel);
                locacaoContext.SaveChanges();
                marcaModel.Id = marcaDTO.Id;

                return StatusCode(201, marcaDTO);
            }
            [HttpPut]
            public ActionResult<MarcaDTO> Put([FromBody] MarcaDTO marcaDTO)
            {


                var marcaModel = new MarcaModel();
                marcaModel.Id = marcaDTO.Id;
                marcaModel.Nome = marcaDTO.Nome;

                locacaoContext.Marca.Attach(marcaModel);
                locacaoContext.SaveChanges();

                return Ok(marcaDTO);
            }


            [HttpGet]
            public ActionResult<List<MarcaDTO>> Get()
            {
                var listaMarcaModel = locacaoContext.Marca;
                List<MarcaDTO> listaGetDto = new List<MarcaDTO>();

                foreach (var item in listaMarcaModel)
                {
                    var marcaDTO = new MarcaDTO();
                    marcaDTO.Id = item.Id;
                    marcaDTO.Nome = item.Nome;

                    listaGetDto.Add(marcaDTO);
                }

                return Ok(listaGetDto);

            }

            [HttpGet("{id}")]
            public ActionResult<MarcaDTO> Get([FromRoute] int id)
            {
                //Buscar o registro no banco de dados por >>>ID<<<
                var marcaModel = locacaoContext.Marca.Find(id);
                // var enfermeiroMoldel = bancoDadosContext.Enfermeiro.Where(w => w.Id == id).FirstOrDefault();

                if (marcaModel == null)
                {
                    return NotFound("Dados não encontrados no banco de dados");
                }

                MarcaDTO marcaDTO = new MarcaDTO();
                marcaDTO.Id = marcaModel.Id;
                marcaDTO.Nome = marcaModel.Nome;

                return Ok(marcaDTO);
            }



            [HttpDelete("{id}")]
            public ActionResult Delete([FromRoute] int id)
            {
                //Verificar se existe registro no banco de dados
                var marcaModel = locacaoContext.Marca.Find(id);

                //Verificar se o registro est� diferente de null
                if (marcaModel != null)
                {
                    //Deletar o regitro no banco de dados

                    locacaoContext.Marca.Remove(marcaModel);
                    locacaoContext.SaveChanges();

                    return Ok();

                }
                else
                {
                    //se for null retorno um request de erro
                    return NotFound("Código não existente ");
                }

            }

        }
}

