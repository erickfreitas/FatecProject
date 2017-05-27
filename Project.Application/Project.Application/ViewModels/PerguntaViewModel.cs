using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class PerguntaViewModel
    {
        [Key]
        public int PerguntaId { get; set; }

        public string Descricao { get; set; }

        public IEnumerable<RespostaViewModel> RespostasViewModels { get; set; }

    }
}
