using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Entidades.Comentarios;
using TrelloAPI.Repositorios.Implementacoes;
using TrelloAPI.Repositorios.Interfaces;

namespace TrelloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepositorio _comentario { get; set; }

        public ComentarioController(IComentarioRepositorio comentario)
        {
            _comentario = comentario;
        }

        [HttpPost("cadastrarComentarioCard")]
        public Retorno<bool> CadastrarComentario([FromBody] ComentarioCadastro comentarioCadastro)
        {
            var resultado = _comentario.CadastrarComentario(comentarioCadastro);
            return new Retorno<bool>(true);
        }

        [HttpPut("atualizarComentarioCard")]
        public Retorno<bool> AlterarComentario([FromBody] ComentarioAlteracao comentarioAlteracao)
        {
            var resultado = _comentario.AlterarComentario(comentarioAlteracao);
            return new Retorno<bool>(resultado);
        }

        [HttpDelete("deletarComentarioCard")]
        public Retorno<bool> DeletarComentario(int id)
        {
            var resultado = _comentario.DeletarComentario(id);
            return new Retorno<bool>(resultado);
        }
    }
}
