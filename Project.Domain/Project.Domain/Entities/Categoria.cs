using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public bool MostrarNoMenuInicial { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<SubCategoria> SubCategorias { get; set; }
    }
}
