namespace Project.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int SubCategoriaId { get; set; }
        public SubCategoria SubCategoria { get; set; }
    }
}
