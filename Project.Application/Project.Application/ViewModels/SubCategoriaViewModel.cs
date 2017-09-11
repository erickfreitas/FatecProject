using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class SubCategoriaViewModel
    {
        [Key]
        public int SubCategoriaId { get; set; }

        [Required(ErrorMessage = "Por favor informe um Nome para a Sub-categoria")]
        [MinLength(2, ErrorMessage = "O nome deve conter no mínimo {0} caracteres")]
        [MaxLength(30, ErrorMessage = "O nome deve conter no máximo {0} caracteres")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }

        public bool MostrarNoMenuInicial { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataAlteracao { get; set; }

        public CategoriaViewModel CategoriaViewModel { get; set; }        
    }
}
