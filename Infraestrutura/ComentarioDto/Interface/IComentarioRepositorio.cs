using TrelloAPI.Infraestrutura.Comentario.Entidade;

namespace TrelloAPI.Infraestrutura.Comentario.Interface
{
    public interface IComentarioRepositorio
    {
        bool CadastrarComentario(ComentarioCadastro comentarioCadastro);
        bool AlterarComentario(ComentarioAlteracao comentarioAlteracao);
        bool DeletarComentario(int id);
    }
}
