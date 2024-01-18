using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Repositorios.Interfaces;
using TrelloAPI.Servicos.CardServicos;

namespace TrelloAPI.Controllers
{
    [ApiController]
    [Route("cards")]
    [Produces("application/json")]
    public class CardsController : ControllerBase
    {
        private readonly ICardServico _servico;

        public CardsController(ICardServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Route("{id}")]
        public Retorno<Card?> ObterCardCompletoPorId(int id)
        {
            return _servico.ObterCardCompletoPorId(id);
        }

        [HttpGet("obterTodosCards")]
        public Retorno<List<Card>> ObterTodosCards()
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
        public Retorno<List<Card>> ObterTopCard()
        {
            return _servico.ObterTopCard();
        }

        [HttpGet("obterCards")]
        public ObterCardsRetorno ObterCards()
        {
            return _servico.ObterTodosCardsComComentario();
        }

        [HttpGet("obterCardPorTitulo")]
        public Retorno<List<Card>> ObterCardPorTitulo(string titulo)
        {
            return _servico.ObterCardPorTitulo(titulo);
        }

        [HttpGet("obterCardPorPalavraChave")]
        public Retorno<List<Card>> ObterCardPorPalavraChave(string palavra)
        {
            return _servico.ObterCardPorPalavraChave(palavra);
        }

        //[HttpGet("obterPalavraChave")]
        //public List<string> ObterPalavraChave()
        //{
        //    return _repositorio.;
        //}
    }
}