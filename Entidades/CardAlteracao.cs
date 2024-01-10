namespace TrelloAPI.Entidades
{
    public class CardAlteracao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public EtiquetasCard Etiqueta { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
