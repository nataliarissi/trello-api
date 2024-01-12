using TrelloAPI.Entidades;
using TrelloAPI.Repositorios.Interfaces;

namespace TrelloAPI.Servicos
{
    public class CardServico : ICardServico
    {
        private ICardRepositorio _repositorio;
        public CardServico(ICardRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ObterCardsRetorno ObterTodosCardsComComentario()
        {
            var retornoCards = new ObterCardsRetorno();

            var cards = _repositorio.ObterCardDoBanco();
            
            retornoCards.Streamer = cards.FirstOrDefault(x => x.Categoria == "Streamer");
            retornoCards.Anime = cards.FirstOrDefault(x => x.Categoria == "Anime");
            retornoCards.Tecnologia = cards.FirstOrDefault(x => x.Categoria == "Tecnologia");
            retornoCards.Jogo = cards.FirstOrDefault(x => x.Categoria == "Jogo");
            retornoCards.Estudo = cards.FirstOrDefault(x => x.Categoria == "Estudo");

            var comentarios = _repositorio.ObterComentarios();

            var comentariosStreamer = comentarios.Where(x => x.IdCard == retornoCards.Streamer.Id).ToList();
            var comentariosAnime = comentarios.Where(x => x.IdCard == retornoCards.Anime.Id).ToList();
            var comentariosJogo = comentarios.Where(x => x.IdCard == retornoCards.Jogo.Id).ToList();
            var comentariosTecnologia = comentarios.Where(x => x.IdCard == retornoCards.Tecnologia.Id).ToList();
            var comentariosEstudo = comentarios.Where(x => x.IdCard == retornoCards.Estudo.Id).ToList();

            foreach (var comentario in comentariosStreamer)
            {
                retornoCards.Streamer.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosAnime)
            {
                retornoCards.Anime.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosJogo)
            {
                retornoCards.Jogo.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosTecnologia)
            {
                retornoCards.Tecnologia.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosEstudo)
            {
                retornoCards.Estudo.Comentarios.Add(comentario);
            }

            return retornoCards;
        }
    }
}
