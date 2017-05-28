namespace Project.Domain.Entities
{
    public class Resposta
    {
        public int RespostaId { get; set; }

        public int PerguntaId { get; set; }

        public virtual Pergunta Pergunta { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public string Descricao { get; set; }
    }
}
