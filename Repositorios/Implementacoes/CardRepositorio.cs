using System.Data.SqlClient;
using TrelloAPI.Entidades;
using TrelloAPI.Repositorios.Interfaces;
using Dapper;

namespace TrelloAPI.Repositorios.Implementacoes
{
    public class CardRepositorio : ICardRepositorio
    {
        private string _connectionString { get; set; }

        public CardRepositorio(){
            _connectionString = "Data Source=.;Initial Catalog=Trello;User ID=sa;Password=Natalia@123;";
        }

        public Card? ObterCardCompletoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)){
                string querySql = "select * from Card where id = @id";

                return connection.QueryFirstOrDefault<Card>(querySql, new {id});
            }

        }
    }
}