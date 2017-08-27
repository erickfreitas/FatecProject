using System;

namespace Project.Application.ViewModels
{
    public class PerguntaUsuarioViewModel
    {
        public int PerguntaId { get; set; }
        public string Descricao { get; set; }
        public RespostaViewModel RespostaViewModels { get; set; }
        public string UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string ImagemCaminho { get; set; }
    }
}
