
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

        public CardsController(ICardRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("{id}")]
        public Retorno<Card?> ObterCardCompletoPorId(int id)
        {
            Card? cardCompleto = _repositorio.ObterCardCompletoPorId(id);
            if (cardCompleto == null)
            {
                return new Retorno<Card?>("Não foi possível encontrar o card solicitado");
            }
            return new Retorno<Card?>(cardCompleto);

            // if(cardCompleto.Etiqueta == EtiquetasCard.Vermelho)
        }

        [HttpGet("obterTodosCards")]
        public Retorno<List<Card>> ObterTodosCards()
        {
            List<Card> listaCards = _repositorio.ListarTodosCards();
            return new Retorno<List<Card>>(listaCards);
        }

        [HttpPost("cadastrarCard")]
        public Retorno<bool> CadastrarCard([FromBody] CardCadastro cardCadastro)
        {
            //if(card.Etiqueta == EtiquetasCard.Vermelho && !(cardCadastro.DataInicio > DateTime.Now)){
            //    return new Retorno<bool>("Erro de etiqueta ou data");
            //}
            // if(card.Titulo){
            //     return new Retorno<bool>("Título já existe no banco de dados");                
            // }

            if (cardCadastro.Titulo.Contains("Amor") && cardCadastro.Etiqueta != EtiquetasCard.Vermelho)
            {
                return new Retorno<bool>("Erro de escrita");
            }
            if (cardCadastro.DataEntrega <= DateTime.Now)
            {
                return new Retorno<bool>("Erro de data");
            }

            var resultado = _repositorio.CadastrarCard(cardCadastro);
            return new Retorno<bool>(true);
        }

        [HttpPut("alterarCard")]
        public Retorno<bool> AlterarDadosCard([FromBody] CardAlteracao cardAlteracao)
        {
            var resultado = _repositorio.AlterarDadosCard(cardAlteracao);
            return new Retorno<bool>(resultado);
        }

        [HttpDelete("deletarCard")]
        public Retorno<bool> DeletarCard(int id)
        {
            var resultado = _repositorio.DeletarCard(id);
            return new Retorno<bool>(resultado);
        }

        [HttpGet("obterTop3Card")]
        public Retorno<List<Card>> ObterTopCard()
        {
            List<Card> listaTopCards = _repositorio.ObterTopCard();
            return new Retorno<List<Card>>(listaTopCards);
        }
    }
}