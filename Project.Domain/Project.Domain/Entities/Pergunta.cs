using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class Pergunta
    {

        



        public int PerguntaId { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public virtual Resposta Resposta { get; set; }
        public string Descricao { get; set; }

        



    }
}
