using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Infraestrutura;
using TrelloAPI.Infraestrutura.Comentario.Entidade;
using TrelloAPI.Servico.CardServicos.Interface;

namespace TrelloAPI.Controllers
{
    [Route("/comentarios")]
    [ApiController]
    [Authorize]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioServico _comentarioServico;

        public ComentarioController(IComentarioServico comentarioServico)
        {
            _comentarioServico = comentarioServico;
        }

        [HttpPost("cadastrarComentarioCard")]
        public Retorno<bool> CadastrarComentario([FromBody] ComentarioCadastro comentarioCadastro)
        {
            return _comentarioServico.CadastrarComentario(comentarioCadastro);
        }

        [HttpPut("atualizarComentarioCard")]
        public Retorno<bool> AlterarComentario([FromBody] ComentarioAlteracao comentarioAlteracao)
        {
            return _comentarioServico.AlterarComentario(comentarioAlteracao);
        }

        [HttpDelete("deletarComentarioCard")]
        public Retorno<bool> DeletarComentario(int id)
        {
            return _comentarioServico.DeletarComentario(id);
        }
    }
}
