using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Entidades.Comentarios;
using TrelloAPI.Repositorios.Implementacoes;
using TrelloAPI.Repositorios.Interfaces;
using TrelloAPI.Servicos.ComentarioServicos;

namespace TrelloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioServico _comentarioServico;

        public ComentarioController(IComentarioServico comentarioServico)
        {
            _comentarioServico = comentarioServico;
        }

        [HttpPost("cadastrarComentarioCard")]
        [Authorize]
        public Retorno<bool> CadastrarComentario([FromBody] ComentarioCadastro comentarioCadastro)
        {
            return _comentarioServico.CadastrarComentario(comentarioCadastro);
        }

        [HttpPut("atualizarComentarioCard")]
        [Authorize]
        public Retorno<bool> AlterarComentario([FromBody] ComentarioAlteracao comentarioAlteracao)
        {
            return _comentarioServico.AlterarComentario(comentarioAlteracao);
        }

        [HttpDelete("deletarComentarioCard")]
        [Authorize]
        public Retorno<bool> DeletarComentario(int id)
        {
            return _comentarioServico.DeletarComentario(id);
        }
    }
}
