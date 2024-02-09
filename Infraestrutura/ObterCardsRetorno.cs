using TrelloAPI.Entidades.Cards;

namespace TrelloAPI.Infraestrutura
{
    public class ObterCardsRetorno
    {
        public CardDto Streamer { get; set; }
        public CardDto Jogo { get; set; }
        public CardDto Anime { get; set; }
        public CardDto Estudo { get; set; }
        public CardDto Tecnologia { get; set; }
    }
}
