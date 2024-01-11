using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TrelloAPI.Entidades;
using TrelloAPI.Repositorios.Interfaces;

namespace TrelloAPI.Repositorios.Implementacoes
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private string _connectionString { get; set; }

        public ComentarioRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Trello");
        }

        public CardComentario cadastrarComentario([FromBody] CardComentario cardComentario)
        {
            return null;
        }

        public bool AlterarComentario([FromBody] CardComentario cardComentario)
        {
            return false;
        }

        public bool DeletarComentario(int id)
        {
            return false;
        }
    }
}
