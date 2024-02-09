namespace TrelloAPI.Infraestrutura.Comentario.Entidade
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public int IdCard { get; set; }
        public string CaixaTexto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataInicio { get; set; }
        public QuantidadeEstrelas Estrelas { get; set; }
    }
}