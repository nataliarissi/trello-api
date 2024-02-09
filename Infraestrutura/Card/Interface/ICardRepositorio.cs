using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Infraestrutura.Comentario.Entidade;
using TrelloAPI.Infraestrutura.Entidades.Card.Entidade;

namespace TrelloAPI.Infraestrutura.Card.Interface
{
    public interface ICardRepositorio
    {
        CardDto? ObterCardCompletoPorId(int id);
        List<CardDto> ListarTodosCards();
        bool CadastrarCard([FromBody] CardCadastro cardCadastro);
        bool AlterarDadosCard([FromBody] CardAlteracao cardAlteracao);
        bool DeletarCard(int id);
        List<CardDto> ObterTopCard();
        List<CardDto> ObterCardDoBanco();
        List<ComentarioDto> ObterComentariosPorIdCard(int idCard);
        List<ComentarioDto> ObterComentarios();
        List<CardDto> ObterCardPorTitulo(string titulo);
        List<CardDto> ObterCardPorPalavraChave(string palavra);
    }
}