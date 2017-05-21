using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public int SubCategoriaId { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public virtual ICollection<ProdutoImagem> ProdutoImagens { get; set; }
        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<Resposta> Respostas { get; set; }

       
    }
}
