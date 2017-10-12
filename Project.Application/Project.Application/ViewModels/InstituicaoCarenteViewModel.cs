using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class InstituicaoCarenteViewModel
    {
        [Key]
        public string InstituicaoCarenteId { get; set; }
        public string Nome { get; set; }
        public string Historia { get; set; }
        public string Missao { get; set; }
        public string Visao { get; set; }
        public string Valores { get; set; }
        public string Equipe { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataAlteracao { get; set; }
    }
}
