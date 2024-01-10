using System.Data.SqlClient;
using TrelloAPI.Entidades;
using TrelloAPI.Repositorios.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace TrelloAPI.Repositorios.Implementacoes
{
    public class CardRepositorio : ICardRepositorio
    {
        private string _connectionString { get; set; }

        public CardRepositorio()
        {
            _connectionString = "Data Source=.;Initial Catalog=Trello;User ID=sa;Password=Natalia@123;";
        }

        public Card? ObterCardCompletoPorId(int id)
        {
            var querySql = "SELECT * FROM CARD WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Card>(querySql, new { id });
            }
        }

        public List<Card> ListarTodosCards()
        {
            var querySql = "SELECT * FROM CARD";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Card>(querySql).ToList();
            }
        }

        public bool CadastrarCard([FromBody] CardCadastro cardCadastro)
        {
            var querySql = "INSERT INTO CARD (Titulo, Etiqueta, DataEntrega, DataInicio) values (@Titulo, @Etiqueta, @DataEntrega, GETDATE())";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(querySql,
                new
                {
                    Titulo = cardCadastro.Titulo,
                    Etiqueta = cardCadastro.Etiqueta,
                    DataEntrega = cardCadastro.DataEntrega
                });
                return resultado > 0;
            }
        }

        public bool AlterarDadosCard(CardAlteracao cardAlteracao)
        {
            var querySql = "UPDATE CARD SET Titulo = @Titulo, Etiqueta = @Etiqueta, DataEntrega = @DataEntrega WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(querySql,
                new
                {
                    Id = cardAlteracao.Id,
                    Titulo = cardAlteracao.Titulo,
                    Etiqueta = cardAlteracao.Etiqueta,
                    DataEntrega = cardAlteracao.DataEntrega
                });
                return resultado > 0;
            }
        }
        public bool DeletarCard(int id)
        {
            var querySql = "DELETE CARD WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(querySql,
                new
                {
                    Id = id
                });
                return resultado > 0;
            }
        }
    }
}