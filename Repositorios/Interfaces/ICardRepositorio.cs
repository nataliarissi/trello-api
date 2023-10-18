using TrelloAPI.Entidades;

namespace TrelloAPI.Repositorios.Interfaces
{
    public interface ICardRepositorio
    {
        Card? ObterCardCompletoPorId(int id);
  
    }
}