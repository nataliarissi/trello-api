using System.Data.SqlClient;
using CardDto.Interface;
using Dapper;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Infraestrutura.Comentario.Entidade;
using TrelloAPI.Infraestrutura.Entidades.Card.Entidade;

namespace Infraestrutura.Entidades.Implementacao
{
    public class CardRepositorio : ICardRepositorio
    {
        private string _connectionString { get; set; }

        public CardRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Trello");
        }
        //public CardRepositorio()
        //{
        //    _connectionString = "Data Source=.;Initial Catalog=Trello;User ID=sa;Password=Natalia@123;";
        //}

        public Card? ObterCardCompletoPorId(int id)
        {
            var queryPorID = "SELECT * FROM CARD ORDER BY DATAPUBLICACAO DESC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Card>(queryPorID, new { id });
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

        public bool CadastrarCard(CardCadastro cardCadastro)
        {
            var queryCadastrar = "INSERT INTO CARD (Titulo, Conteudo, Assunto, Etiqueta, DataPublicacao, DataEntrega) values (@Titulo, @Conteudo, @Assunto, @Etiqueta, GETDATE(), @DataEntrega)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(queryCadastrar,
                new
                {
                    cardCadastro.Titulo,
                    cardCadastro.Conteudo,
                    cardCadastro.Assunto,
                    cardCadastro.Etiqueta,
                    cardCadastro.DataEntrega
                });
                return resultado > 0;
            }
        }

        public bool AlterarDadosCard(CardAlteracao cardAlteracao)
        {
            var queryAlterar = "UPDATE CARD SET Titulo = @Titulo, Conteudo = @Conteudo, Assunto = @Assunto, Etiqueta = @Etiqueta, DataEntrega = @DataEntrega WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(queryAlterar,
                new
                {
                    cardAlteracao.Id,
                    cardAlteracao.Titulo,
                    cardAlteracao.Conteudo,
                    cardAlteracao.Assunto,
                    cardAlteracao.Etiqueta,
                    cardAlteracao.DataEntrega
                });
                return resultado > 0;
            }
        }

        public bool DeletarCard(int id)
        {
            var queryDeletar = "DELETE CARD WHERE Id = @Id";

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

        public List<Card> ObterTopCard()
        {
            var queryTop = "SELECT TOP 3 * FROM CARD ORDER BY ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Card>(queryTop).ToList();
            }
        }

        public List<Card> ObterCardDoBanco()
        {
            var queryComentarios = "SELECT * FROM CARD";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Card>(queryComentarios);
                return resultado.ToList();
            }
        }

        public List<Comentario> ObterComentariosPorIdCard(int idCard)
        {
            var queryIdCard = "SELECT * FROM CARDCOMENTARIO WHERE IDCARD = @idCard";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Comentario>(queryIdCard,
                new
                {
                    idCard
                });
                return resultado.ToList();
            }
        }

        public List<Comentario> ObterComentarios()
        {
            var queryComentarios = "SELECT * FROM CARDCOMENTARIO ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Comentario>(queryComentarios);
                return resultado.ToList();
            }
        }

        public List<Card> ObterCardPorTitulo(string titulo)
        {
            var queryTitulo = "SELECT * FROM CARD WHERE Titulo Like '%' + @titulo + '%'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Card>(queryTitulo,
                new
                {
                    titulo
                });
                return resultado.ToList();
            }
        }

        public List<Card> ObterCardPorPalavraChave(string palavra)
        {
            var queryCardPalavraChave = "SELECT * FROM CARD WHERE TITULO LIKE '%' PALAVRA '%' OR CONTEUDO LIKE '%' PALAVRA '%'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Card>(queryCardPalavraChave,
                new
                {
                    palavra
                });
                return resultado.ToList();
            }
        }
    }
}