using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class RespostaViewModel
    {
        [Required]
        public int RespostaId { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}
