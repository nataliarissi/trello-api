
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;
using TrelloAPI.Repositorios.Interfaces;

namespace TrelloAPI.Controllers
{
    [ApiController]
    [Route("cards")]
    [Produces("application/json")]
    public class CardsController : ControllerBase
    {
        private ICardRepositorio _repositorio { get; set; }

        public CardsController(ICardRepositorio repositorio){
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("{id}")]
        public Retorno<Card?> ObterCardCompletoPorId(int id){
            Card? cardCompleto = _repositorio.ObterCardCompletoPorId(id);
            if(cardCompleto == null){
                return new Retorno<Card?>("Não foi possível encontrar o card solicitado"); 
            }
            return new Retorno<Card?>(cardCompleto);

            // if(cardCompleto.Etiqueta == EtiquetasCard.Vermelho)
        }

        [HttpGet]
        public Retorno<List<Card>> ObterTodosCards(){
            throw new Exception("Não implementado ainda");
        }
        
        [HttpPost]
        public Retorno<bool> CadastrarCard([FromBody]Card card){
            throw new Exception("Não implementado ainda");
        }

        [HttpPut]
        public Retorno<bool> AlterarDadosCard(Card card){
            throw new Exception("Não implementado ainda");
        }
        
        [HttpDelete]
        public Retorno<bool> DeletarCard(int id){
            throw new Exception("Não implementado ainda");
        }
    }
}