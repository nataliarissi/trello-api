
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;

namespace TrelloAPI.Controllers
{
    [ApiController]
    [Route("cards")]
    [Produces("application/json")]
    public class CardsController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public Card ObterCardCompletoPorId(int id){
            throw new Exception("Não implementado ainda");
        }

        [HttpGet]
        public List<Card> ObterTodosCards(){
            throw new Exception("Não implementado ainda");
        }
        
        [HttpPost]
        public bool CadastrarCard(Card card){
            throw new Exception("Não implementado ainda");
        }

        [HttpPut]
        public bool AlterarDadosCard(Card card){
            throw new Exception("Não implementado ainda");
        }
        
        [HttpDelete]
        public bool DeletarCard(int id){
            throw new Exception("Não implementado ainda");
        }
    }
}