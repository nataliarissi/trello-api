using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Infraestrutura;
using TrelloAPI.Infraestrutura.Entidades.Card.Entidade;

namespace TrelloAPI.Servico.CardServicos.Interface
{
    public interface ICardServico
    {
        ObterCardsRetorno ObterTodosCardsComComentario();

        Retorno<CardDto?> ObterCardCompletoPorId(int id);
        Retorno<List<CardDto>> ObterTodosCards();
        Retorno<bool> CadastrarCard([FromBody] CardCadastro cardCadastro);
        Retorno<bool> AlterarDadosCard([FromBody] CardAlteracao cardAlteracao);
        Retorno<bool> DeletarCard(int id);
        Retorno<List<CardDto>> ObterTopCard();
        Retorno<List<CardDto>> ObterCardPorTitulo(string titulo);
        Retorno<List<CardDto>> ObterCardPorPalavraChave(string palavra);
    }
}