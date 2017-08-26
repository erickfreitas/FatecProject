using System;

namespace Project.Domain.Entities
{
    public class Resposta
    {
        public int RespostaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
