using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Entidades.Comentarios;
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

        public bool CadastrarComentario(ComentarioCadastro comentarioCadastro)
        {
            var queryCadastrar = "INSERT INTO CARDCOMENTARIO (IdCard, CaixaTexto, IdUsuario, QUANTIDADEESTRELAS, DataInicio) values (@IdCard, @CaixaTexto, @IdUsuario, @QUANTIDADEESTRELAS, GETDATE())";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(queryCadastrar,
                new
                {
                    IdCard = comentarioCadastro.IdCard,
                    CaixaTexto = comentarioCadastro.CaixaTexto,
                    IdUsuario = comentarioCadastro.IdUsuario,
                    QUANTIDADEESTRELAS = comentarioCadastro.Estrelas
                });
                return resultado > 0;
            }
        }

        public bool AlterarComentario(ComentarioAlteracao comentarioAlteracao)
        {
            var queryAlterar = "UPDATE CARDCOMENTARIO SET CaixaTexto = @CaixaTexto, QUANTIDADEESTRELAS = @QUANTIDADEESTRELAS WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(queryAlterar,
                new
                {
                    Id = comentarioAlteracao.Id,
                    CaixaTexto = comentarioAlteracao.CaixaTexto,
                    QUANTIDADEESTRELAS = comentarioAlteracao.Estrelas,
                });
                return resultado > 0;
            }
        }

        public bool DeletarComentario(int id)
        {
            var queryDeletar = "DELETE CARDCOMENTARIO WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(queryDeletar,
                new
                {
                    Id = id
                });
                return resultado > 0;
            }
        }
    }
}
