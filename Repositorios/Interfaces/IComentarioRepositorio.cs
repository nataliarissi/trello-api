using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades;
using TrelloAPI.Repositorios.Implementacoes;

namespace TrelloAPI.Repositorios.Interfaces
{
    public class IComentarioRepositorio
    {
        CardComentario cadastrarComentario([FromBody] CardComentario cardComentario);
        bool AlterarComentario([FromBody] CardComentario cardComentario);
        bool DeletarComentario(int id);
    }
}
