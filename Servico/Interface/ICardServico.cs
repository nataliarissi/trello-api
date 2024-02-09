using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Infraestrutura;
using TrelloAPI.Infraestrutura.Entidades.Card.Entidade;

namespace TrelloAPI.Servico.CardServicos.Interface
{
    public interface ICardServico
    {
        ObterCardsRetorno ObterTodosCardsComComentario();

        Retorno<Card?> ObterCardCompletoPorId(int id);
        Retorno<List<Card>> ObterTodosCards();
        Retorno<bool> CadastrarCard([FromBody] CardCadastro cardCadastro);
        Retorno<bool> AlterarDadosCard([FromBody] CardAlteracao cardAlteracao);
        Retorno<bool> DeletarCard(int id);
        Retorno<List<Card>> ObterTopCard();
        Retorno<List<Card>> ObterCardPorTitulo(string titulo);
        Retorno<List<Card>> ObterCardPorPalavraChave(string palavra);
    }
}