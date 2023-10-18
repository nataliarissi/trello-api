
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
        public Card? ObterCardCompletoPorId(int id){
            return _repositorio.ObterCardCompletoPorId(id);
        }

        [HttpGet]
        public List<Card> ObterTodosCards(){
            throw new Exception("Não implementado ainda");
        }
        
        [HttpPost]
        public bool CadastrarCard([FromBody]Card card){
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