using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;

namespace TrelloAPI.Repositorios.Interfaces
{
    public interface ICardRepositorio
    {
        Card? ObterCardCompletoPorId(int id);
        List<Card> ListarTodosCards();
        bool CadastrarCard([FromBody] CardCadastro cardCadastro);
        bool AlterarDadosCard(CardAlteracao cardAlteracao);
        bool DeletarCard(int id);
    }
}