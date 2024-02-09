using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Entidades.Cards;
using TrelloAPI.Infraestrutura;
using TrelloAPI.Infraestrutura.Card.Interface;
using TrelloAPI.Infraestrutura.Entidades.Card.Entidade;
using TrelloAPI.Servico.CardServicos.Interface;

namespace TrelloAPI.Servico.Implementacao
{
    public class CardServico : ICardServico
    {
        private readonly ICardRepositorio _repositorio;
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

        public Retorno<CardDto?> ObterCardCompletoPorId(int id)
        {
            try
            {
                CardDto? cardCompleto = _repositorio.ObterCardCompletoPorId(id);
                if (cardCompleto == null)
                {
                    return new Retorno<CardDto?>("Não foi possível encontrar o card solicitado");
                }
                var listaComentarios = _repositorio.ObterComentariosPorIdCard(id);

                foreach (var comentario in listaComentarios)
                {
                    cardCompleto.Comentarios.Add(comentario);
                }

                return new Retorno<CardDto?>(cardCompleto);
            }
            catch (Exception ex)
            {
                new Retorno<CardDto>("Erro ao obter card completo" + ex.Message);
            }
            // if(cardCompleto.Etiqueta == EtiquetasCard.Vermelho)

            return new Retorno<CardDto?>("");
        }

        public Retorno<List<CardDto?>> ObterTodosCards()
        {
            try
            {
                List<CardDto> listaCards = _repositorio.ListarTodosCards();

                if (listaCards == null)
                    return new Retorno<List<CardDto?>>("Erro ao obter todos os cards");

                return new Retorno<List<CardDto?>>(listaCards);
            }
            catch (Exception ex)
            {
                new Retorno<List<CardDto?>>("Erro ao obter a lista dos cards" + ex.Message);
            }

            return new Retorno<List<CardDto?>>("");
        }

        public Retorno<bool> CadastrarCard([FromBody] CardCadastro cardCadastro)
        {
            try
            {
                //if(card.Etiqueta == EtiquetasCard.Vermelho && !(cardCadastro.DataInicio > DateTime.Now)){
                //    return new Retorno<bool>("Erro de etiqueta ou data");
                //}
                // if(card.Titulo){
                //     return new Retorno<bool>("Título já existe no banco de dados");                
                // }

                if (cardCadastro.Titulo.Contains("Amor") && cardCadastro.Etiqueta != EtiquetasCard.Vermelho)
                {
                    return new Retorno<bool>("Erro de escrita");
                }
                if (cardCadastro.DataEntrega <= DateTime.Now)
                {
                    return new Retorno<bool>("Erro de data");
                }

                var resultado = _repositorio.CadastrarCard(cardCadastro);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao cadastrar o card");

                return new Retorno<bool>(resultado);
                //return new Retorno<bool>(true);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<bool> AlterarDadosCard([FromBody] CardAlteracao cardAlteracao)
        {
            try
            {
                var resultado = _repositorio.AlterarDadosCard(cardAlteracao);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao alterar o card");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<bool> DeletarCard(int id)
        {
            try
            {
                var resultado = _repositorio.DeletarCard(id);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao deletar o card");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<List<CardDto>> ObterTopCard()
        {
            try
            {
                List<CardDto> listaTopCards = _repositorio.ObterTopCard();

                if (listaTopCards == null)
                    return new Retorno<List<CardDto>>("");

                return new Retorno<List<CardDto>>(listaTopCards);
            }
            catch (Exception ex)
            {
                return new Retorno<List<CardDto>>("Erro" + ex.Message);
            }
        }

        public Retorno<List<CardDto?>> ObterCardPorTitulo(string titulo)
        {
            try
            {
                var resultado = _repositorio.ObterCardPorTitulo(titulo);

                if (resultado == null)
                    return new Retorno<List<CardDto?>>("Card não encontrado");

                return new Retorno<List<CardDto?>>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<List<CardDto>>("Erro" + ex.Message);
            }
        }

        public Retorno<List<CardDto>> ObterCardPorPalavraChave(string palavra)
        {
            try
            {
                var resultado = _repositorio.ObterCardPorPalavraChave(palavra);

                if (resultado == null)
                    return new Retorno<List<CardDto>>("Erro ao obter a palavra chave");

                return new Retorno<List<CardDto>>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<List<CardDto>>("Erro" + ex.Message);
            }
        }
    }
}