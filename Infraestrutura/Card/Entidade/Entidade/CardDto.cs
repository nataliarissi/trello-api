using TrelloAPI.Infraestrutura.Comentario.Entidade;
using TrelloAPI.Infraestrutura.Entidades.Card.Entidade;

namespace TrelloAPI.Entidades.Cards
{
    public class CardDto
    {
        public CardDto()
        {
            Comentarios = new List<ComentarioDto>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public TipoAssunto Assunto { get; set; }
        public string Categoria { get; set; }
        public EtiquetasCard Etiqueta { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public List<ComentarioDto> Comentarios { get; set; }
    }
}