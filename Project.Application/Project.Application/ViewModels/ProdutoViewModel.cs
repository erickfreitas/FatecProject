using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Por favor informe um Nome para o Produto")]
        [MinLength(2, ErrorMessage = "O nome deve conter no mínimo {0} caracteres")]
        [MaxLength(50, ErrorMessage = "O nome deve conter no máximo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor informe uma Descrição para o Produto")]
        [MinLength(2, ErrorMessage = "A Decrição deve conter no mínimo {0} caracteres")]
        [MaxLength(50, ErrorMessage = "A Decrição deve conter no máximo {0} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor informe os Detalhes do Produto")]
        [MinLength(2, ErrorMessage = "Os Detalhes devem conter no mínimo {0} caracteres")]
        [MaxLength(1500, ErrorMessage = "Os Detalhes devem conter no máximo {0} caracteres")]
        public string Detalhes { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        public int SubCategoriaId { get; set; }
    }
}
