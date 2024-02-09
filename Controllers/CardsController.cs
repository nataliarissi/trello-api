using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Infraestrutura;
using TrelloAPI.Infraestrutura.Entidades.Card.Entidade;
using TrelloAPI.Servico.CardServicos.Interface;

namespace TrelloAPI.Controllers
{
    [ApiController]
    [Route("/cards")]
    [Produces("application/json")]
    [Authorize]
    public class CardsController : ControllerBase
    {
        private readonly ICardServico _servico;

        public CardsController(ICardServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Route("{id}")]
        public Retorno<CardDto?> ObterCardCompletoPorId(int id)
        {
            return _servico.ObterCardCompletoPorId(id);
        }

        [HttpGet("obterTodosCards")]
        public Retorno<List<CardDto>> ObterTodosCards()
        {
            return _servico.ObterTodosCards();
        }

        [HttpPost("cadastrarCard")]
        public Retorno<bool> CadastrarCard([FromBody] CardCadastro cardCadastro)
        {
            return _servico.CadastrarCard(cardCadastro);
        }

        [HttpPut("alterarCard")]
        public Retorno<bool> AlterarDadosCard([FromBody] CardAlteracao cardAlteracao)
        {
            return _servico.AlterarDadosCard(cardAlteracao);
        }

        [HttpDelete("deletarCard")]
        public Retorno<bool> DeletarCard(int id)
        {
            return _servico.DeletarCard(id);
        }

        [HttpGet("obterTop3Card")]
        public Retorno<List<CardDto>> ObterTopCard()
        {
            return _servico.ObterTopCard();
        }

        [HttpGet("obterCards")]
        public ObterCardsRetorno ObterCards()
        {
            return _servico.ObterTodosCardsComComentario();
        }

        [HttpGet("obterCardPorTitulo")]
        public Retorno<List<CardDto>> ObterCardPorTitulo(string titulo)
        {
            return _servico.ObterCardPorTitulo(titulo);
        }

        [HttpGet("obterCardPorPalavraChave")]
        public Retorno<List<CardDto>> ObterCardPorPalavraChave(string palavra)
        {
            return _servico.ObterCardPorPalavraChave(palavra);
        }
    }
}

//[HttpGet("obterPalavraChave")]
//public List<string> ObterPalavraChave()
//{
//    return _repositorio.;
//}