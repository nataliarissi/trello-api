using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Comentarios;
using TrelloAPI.Entidades;

namespace TrelloAPI.Servicos.ComentarioServicos
{
    public interface IComentarioServico
    {
        Retorno<bool> CadastrarComentario([FromBody] ComentarioCadastro comentarioCadastro);
        Retorno<bool> AlterarComentario([FromBody] ComentarioAlteracao comentarioAlteracao);
        Retorno<bool> DeletarComentario(int id);
    }
}
