﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
    public class Troca
    {
        public int IdTroca { get; set; }
        public int IdProdutoProposto { get; set; }
        public int IdProdutoSujeito { get; set; }
        public string DsTrocaProposta { get; set; }
        public string DsTrocaSujeito { get; set; }
        public bool FlTrocaProposta { get; set; }
        public bool FlTrocaAceita { get; set; }
        public bool FlTrocaRealizada { get; set; }
        public bool FlTrocaRejeitada { get; set; }
        public DateTime DtTrocaProposta { get; set; }
        public DateTime DtTrocaAceita { get; set; }
        public DateTime DtTrocaRealizada { get; set; }
        public DateTime DtTrocaRejeitada { get; set; }
        public virtual Produto Produto{ get; set; }        
    }
}
