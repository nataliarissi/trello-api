using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Entidades.Comentarios;

namespace TrelloAPI.Repositorios.Interfaces
{
    public interface IComentarioRepositorio
    {
        bool CadastrarComentario(ComentarioCadastro comentarioCadastro);
        bool AlterarComentario(ComentarioAlteracao comentarioAlteracao);
        bool DeletarComentario(int id);
    }
}
