using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            SubCategoriaViewModels = new List<SubCategoriaViewModel>();
        }

        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Por favor informe um Nome para a Categoria")]
        [MinLength(2, ErrorMessage = "O nome deve conter no mínimo {1} caracteres")]
        [MaxLength(30, ErrorMessage = "O nome deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        public bool MostrarNoMenuInicial { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataAlteracao { get; set; }

        public List<SubCategoriaViewModel> SubCategoriaViewModels { get; set; }
    }
}
