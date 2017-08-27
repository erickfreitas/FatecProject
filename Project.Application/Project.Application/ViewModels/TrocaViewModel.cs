namespace Project.Application.ViewModels
{
    public class TrocaViewModel
    {
        public int IdTroca { get; set; }
        public int IdProdutoProposto { get; set; }
        public int IdProdutoSujeito { get; set; }
        public string DsTrocaProposta { get; set; }
        public string DsTrocaSujeito { get; set; }
        public bool FlTrocaProposta { get; set; }
        public bool FlTrocaRealizada { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }

    }
}
