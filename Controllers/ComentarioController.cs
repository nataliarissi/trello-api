using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;
using TrelloAPI.Repositorios.Implementacoes;
using TrelloAPI.Repositorios.Interfaces;

namespace TrelloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepositorio _repositorio { get; set; }

        public ComentarioController(IComentarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost("cadastrarComentarioCard")]
        Retorno<CardComentario> cadastrarComentario([FromBody] CardComentario cardComentario)
        {
            return null;
        }

        [HttpPut("atualizarComentarioCard")]
        public Retorno<bool> AlterarComentario([FromBody] CardComentario cardComentario)
        {
            return null;
        }

        [HttpDelete("deletarComentarioCard")]
        public Retorno<bool> DeletarComentario(int id)
        {
            return null;
        }
    }
}
