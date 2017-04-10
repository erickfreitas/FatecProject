using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Por favor informe um Nome para a Categoria")]
        [MinLength(2, ErrorMessage = "O nome deve conter no mínimo {0} caracteres")]
        [MaxLength(30, ErrorMessage = "O nome deve conter no máximo {0} caracteres")]
        public string Nome { get; set; }
    }
}
