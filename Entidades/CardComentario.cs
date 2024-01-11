namespace TrelloAPI.Entidades
{
    public class CardComentario
    {
        public int Id { get; set; }
        public int IdCard { get; set; }
        public string Comentario { get; set; }
        public string User { get; set; }
        public Enum QuantidadeEstrelas { get; set; }
    }
}