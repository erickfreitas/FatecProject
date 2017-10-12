using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class RegistrarInstituiçãoCarenteViewModel
    {
        [Key]
        public string InstituicaoCarenteId { get; set; }

        [Required(ErrorMessage = "Informe o campo {0}")]
        [DisplayName("Nome da Instituição")]
        [MinLength(3, ErrorMessage = "Mínimo {1} caracteres")]
        [MaxLength(150, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o campo {0}")]
        [DisplayName("História da Instituição")]
        [MinLength(3, ErrorMessage = "Mínimo {1} caracteres")]
        [MaxLength(500, ErrorMessage = "Mínimo {1} caracteres")]
        public string Historia { get; set; }

        [Required(ErrorMessage = "Informe o campo {0}")]
        [DisplayName("Missão da Instituição")]
        [MinLength(3, ErrorMessage = "Mínimo {1} caracteres")]
        [MaxLength(500, ErrorMessage = "Mínimo {1} caracteres")]
        public string Missao { get; set; }

        [Required(ErrorMessage = "Informe o campo {0}")]
        [DisplayName("Visão da Instituição")]
        [MinLength(3, ErrorMessage = "Mínimo {1} caracteres")]
        [MaxLength(300, ErrorMessage = "Mínimo {1} caracteres")]
        public string Visao { get; set; }

        [Required(ErrorMessage = "Informe o campo {0}")]
        [DisplayName("Valores da Instituição")]
        [MinLength(3, ErrorMessage = "Mínimo {1} caracteres")]
        [MaxLength(500, ErrorMessage = "Mínimo {1} caracteres")]
        public string Valores { get; set; }

        [Required(ErrorMessage = "Informe o campo {0}")]
        [DisplayName("Equipe")]
        [MinLength(3, ErrorMessage = "Mínimo {1} caracteres")]
        [MaxLength(300, ErrorMessage = "Mínimo {1} caracteres")]
        public string Equipe { get; set; }

        [Required(ErrorMessage = "Por favor informe um Nome para o Usuário")]
        [MinLength(2, ErrorMessage = "O Nome deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo {1} caracteres")]
        [DisplayName("Nome")]
        public string UsuarioNome { get; set; }

        [MinLength(2, ErrorMessage = "O Sobrenome deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Sobrenome deve conter no máximo {1} caracteres")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [DisplayName("RG")]
        [Required(ErrorMessage = "Por favor informe o campo RG")]
        public string Rg { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Por favor informe o campo CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor informe um E-mail para o Usuário")]
        [EmailAddress(ErrorMessage = "Informe um E-mail com formato válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor informe uma Senha para o Usuário")]
        [MinLength(6, ErrorMessage = "A Senha deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "A Senha deve conter no máximo {1} caracteres")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "A Senha e Confirmação de Senha não conferem")]
        [DisplayName("Confirmar Senha")]
        public string ConfirmarSenha { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataAlteracao { get; set; }
    }
}
