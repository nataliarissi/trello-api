﻿namespace TrelloAPI.Entidades.Comentarios
{
    public class ComentarioCadastro
    {
        public int IdCard { get; set; }
        public string CaixaTexto { get; set; }
        public int IdUsuario { get; set; }
        public QuantidadeEstrelas Estrelas { get; set; }
    }
}
