using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class SubCategoria
    {
        public int SubCategoriaId { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
