using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Entidades.Comentarios;

namespace TrelloAPI.Repositorios.Interfaces
{
    public interface ICardRepositorio
    {
        Card? ObterCardCompletoPorId(int id);
        List<Card> ListarTodosCards();
        bool CadastrarCard([FromBody] CardCadastro cardCadastro);
        bool AlterarDadosCard([FromBody] CardAlteracao cardAlteracao);
        bool DeletarCard(int id);
        List<Card> ObterTopCard();
        List<Card> ObterCardDoBanco();
        List<Comentario> ObterComentariosPorIdCard(int idCard);
        List<Comentario> ObterComentarios();
        List<Card> ObterCardPorTitulo(string titulo);
        List<Card> ObterCardPorPalavraChave(string palavra);
    }
}