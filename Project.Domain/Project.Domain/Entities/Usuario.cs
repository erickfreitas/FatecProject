using System;

namespace Project.Domain.Entities
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmado { get; set; }
        public string Telefone { get; set; }
        public bool TelefoneConfirmado { get; set; }
        public bool DoisFatoresAtivados { get; set; }
        public string HashDeSenha { get; set; }
        public string CarimboDeSeguranca { get; set; }
        public bool BloqueioAtivo { get; set; }
        public DateTime FimDeBloqueio { get; set; }
        public int ContagemFalhaDeAcesso { get; set; }
        public string UsuarioNome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
