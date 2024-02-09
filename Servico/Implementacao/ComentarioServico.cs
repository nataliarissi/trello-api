using Microsoft.AspNetCore.Mvc;
using TrelloAPI.Infraestrutura;
using TrelloAPI.Infraestrutura.Comentario.Entidade;
using TrelloAPI.Infraestrutura.Comentario.Interface;
using TrelloAPI.Servico.CardServicos.Interface;

namespace TrelloAPI.Servico.Implementacao
{
    public class ComentarioServico : IComentarioServico
    {
        private readonly IComentarioRepositorio _repositorio;
        public ComentarioServico(IComentarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Retorno<bool> CadastrarComentario([FromBody] ComentarioCadastro comentarioCadastro)
        {
            try
            {
                var resultado = _repositorio.CadastrarComentario(comentarioCadastro);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao cadastrar comentário no card");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<bool> AlterarComentario([FromBody] ComentarioAlteracao comentarioAlteracao)
        {
            try
            {
                var resultado = _repositorio.AlterarComentario(comentarioAlteracao);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao alterar comentário");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }

        }

        public Retorno<bool> DeletarComentario(int id)
        {
            try
            {
                var resultado = _repositorio.DeletarComentario(id);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao deletar comentário");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }
    }
}