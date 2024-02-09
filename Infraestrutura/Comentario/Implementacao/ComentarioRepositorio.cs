using Dapper;
using System.Data.SqlClient;
using TrelloAPI.Infraestrutura.Comentario.Entidade;
using TrelloAPI.Infraestrutura.Comentario.Interface;

namespace TrelloAPI.Infraestrutura.Comentario.Implementacao
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
                    comentarioCadastro.IdCard,
                    comentarioCadastro.CaixaTexto,
                    comentarioCadastro.IdUsuario,
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
                    comentarioAlteracao.Id,
                    comentarioAlteracao.CaixaTexto,
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
