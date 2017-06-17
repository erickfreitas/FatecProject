using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.ViewModels
{
    public class UsuarioInformacaoViewModel
    {
        public string UsuarioId { get; set; }

        [Required(ErrorMessage = "Por favor informe um Nome para o Usuário")]
        [MinLength(2, ErrorMessage = "O Nome deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo {1} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [MinLength(2, ErrorMessage = "O Sobrenome deve conter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Sobrenome deve conter no máximo {1} caracteres")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [ScaffoldColumn(false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(9, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(9, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(30, ErrorMessage = "Máximo {1} caracteres")]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(155, ErrorMessage = "Máximo {1} caracteres")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(155, ErrorMessage = "Máximo {1} caracteres")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(155, ErrorMessage = "Máximo {1} caracteres")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo {1} caracteres")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo {1} caracteres")]
        [DisplayName("Complemento")]
        public string Numero { get; set; }
    }
}
