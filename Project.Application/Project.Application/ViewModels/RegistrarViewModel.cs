using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class RegistrarViewModel
    {
        [Required(ErrorMessage = "Por favor informe um Nome para o Usuário")]
        [MinLength(2, ErrorMessage = "O Nome deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo {1} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

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
    }
}
