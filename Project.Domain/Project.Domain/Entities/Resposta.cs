﻿namespace Project.Domain.Entities
{
    public class Resposta
    {
        public int RespostaId { get; set; }

        public virtual Pergunta Pergunta { get; set; }

        public string Descricao { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
