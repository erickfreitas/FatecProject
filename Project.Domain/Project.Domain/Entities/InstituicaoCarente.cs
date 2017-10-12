using System;

namespace Project.Domain.Entities
{
    public class InstituicaoCarente
    {
        public string InstituicaoCarenteId { get; set; }
        public string Nome { get; set; }
        public string Historia { get; set; }
        public string Missao { get; set; }
        public string Visao { get; set; }
        public string Valores { get; set; }
        public string Equipe { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
