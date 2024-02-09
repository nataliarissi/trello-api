using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Infraestrutura;
using TrelloAPI.Infraestrutura.Comentario.Entidade;

namespace TrelloAPI.Servico.CardServicos.Interface
{
    public interface IComentarioServico
    {
        Retorno<bool> CadastrarComentario([FromBody] ComentarioCadastro comentarioCadastro);
        Retorno<bool> AlterarComentario([FromBody] ComentarioAlteracao comentarioAlteracao);
        Retorno<bool> DeletarComentario(int id);
    }
}
