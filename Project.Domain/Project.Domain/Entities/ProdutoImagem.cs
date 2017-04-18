namespace Project.Domain.Entities
{
    public class ProdutoImagem
    {
        public int ProdutoImagemId { get; set; }
        public string Caminho { get; set; }
        public bool Destaque { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
