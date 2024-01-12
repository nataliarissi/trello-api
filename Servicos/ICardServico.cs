using TrelloAPI.Entidades;

namespace TrelloAPI.Servicos
{
    public interface ICardServico
    {
        ObterCardsRetorno ObterTodosCardsComComentario();
    }
}