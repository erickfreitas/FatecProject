using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Project.Application.ViewModels
{
    public class PerguntaViewModel
    {
        public PerguntaViewModel()
        {
            
            
                RespostaViewModels = new RespostaViewModel();
            
        }

        [Key]
        public int PerguntaId { get; set; }

        public string Descricao { get; set; }

        
        public RespostaViewModel RespostaViewModels { get; set; }

        public string UsuarioId { get; set; }

        public int ProdutoId { get; set; }


    }
}
