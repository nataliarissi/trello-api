
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
            List<Card> listaCards = _repositorio.ListarTodosCards();
            return new Retorno<List<Card>>(listaCards);
        }
        
        [HttpPost]
        public Retorno<bool> CadastrarCard([FromBody]Card card){
            if(card.Etiqueta == EtiquetasCard.Vermelho && !(card.DataInicio > DateTime.Now)){
                return new Retorno<bool>("Erro de etiqueta ou data");
            }
            if(card.Titulo.Contains("Amor") && card.Etiqueta != EtiquetasCard.Vermelho){
                return new Retorno<bool>("Erro de escrita");
            }
            if(card.DataEntrega <= DateTime.Now){
                return new Retorno<bool>("Erro de data");
            }
            
            // if(card.Titulo){
            //     return new Retorno<bool>("Título já existe no banco de dados");                
            // }
            return new Retorno<bool>(true);
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