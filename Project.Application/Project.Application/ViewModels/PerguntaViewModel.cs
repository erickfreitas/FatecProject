using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{ 
    
    public class PerguntaViewModel
    {
        [Key]
        public int PerguntaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição da Pergunta")]
        public string Descricao { get; set; }        

        public RespostaViewModel RespostaViewModels { get; set; }

        public string UsuarioId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
