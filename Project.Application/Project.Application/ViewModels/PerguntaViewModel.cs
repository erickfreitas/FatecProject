using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class PerguntaViewModel
    {
        [Key]
        public int PerguntaId { get; set; }

        public string Descricao { get; set; }

    }
}
