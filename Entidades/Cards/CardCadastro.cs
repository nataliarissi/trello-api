using TrelloAPI.Entidades.Comentarios;

namespace TrelloAPI.Entidades.Cards
{
    public class CardCadastro
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public TipoAssunto Assunto { get; set; }
        public EtiquetasCard Etiqueta { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
