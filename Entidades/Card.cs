namespace TrelloAPI.Entidades{
    public class Card{
        public int Id { get; set; }
        public string Titulo { get; set; }
        public EtiquetasCard Etiqueta { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}