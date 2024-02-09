using TrelloAPI.Entidades.Cards;

namespace TrelloAPI.Infraestrutura
{
    public class ObterCardsRetorno
    {
        public Card Streamer { get; set; }
        public Card Jogo { get; set; }
        public Card Anime { get; set; }
        public Card Estudo { get; set; }
        public Card Tecnologia { get; set; }
    }
}
