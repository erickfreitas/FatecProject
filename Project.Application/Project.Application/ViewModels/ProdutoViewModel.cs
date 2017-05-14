using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Por favor informe um Nome para o Produto")]
        [MinLength(2, ErrorMessage = "O Nome deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo {1} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor informe uma Descrição para o Produto")]
        [MinLength(2, ErrorMessage = "A Decrição deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "A Decrição deve conter no máximo {1} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor informe os Detalhes do Produto")]
        [MinLength(2, ErrorMessage = "Os Detalhes devem conter no mínimo {1} caracteres")]
        [MaxLength(1500, ErrorMessage = "Os Detalhes devem conter no máximo {1} caracteres")]
        [DisplayName("Detalhes")]
        public string Detalhes { get; set; }        

        [Required]
        [DisplayName("Sub-Categoria")]
        public int SubCategoriaId { get; set; }

        public string UsuarioId { get; set; }

        public SubCategoriaViewModel SubCategoriaViewModel { get; set; }

        public IEnumerable<ProdutoImagemViewModel> ProdutoImagemViewModels { get; set; }
    }
}
