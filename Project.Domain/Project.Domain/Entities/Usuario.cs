using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public bool EmailConfirmado { get; set; }
        public string Telefone { get; set; }
        public bool TelefoneConfirmado { get; set; }
        public bool DoisFatoresAtivados { get; set; }
        public string HashDeSenha { get; set; }
        public string CarimboDeSeguranca { get; set; }
        public bool BloqueioAtivo { get; set; }
        public DateTime? FimDeBloqueio { get; set; }
        public int ContagemFalhaDeAcesso { get; set; }
        public string UsuarioNome { get; set; }
        public virtual ICollection<ClienteWeb> ClientesWeb { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }  
        public virtual  ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<Resposta> Respostas { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }


    }
}
