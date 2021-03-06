﻿using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class TrocaConfiguration : EntityTypeConfiguration<Troca>
    {
        public TrocaConfiguration()
        {
            ToTable("Trocas");

            HasKey(t => t.IdTroca);

            Property(t => t.IdProdutoProposto)
                .IsRequired();

            Property(t => t.IdProdutoSujeito)
                .IsRequired();

            Property(t => t.DsTrocaProposta);

            Property(t => t.DsTrocaSujeito);

            Property(t => t.FlTrocaProposta)
                .IsRequired();

            Property(t => t.FlTrocaRealizada)
                .IsRequired();

            Property(t => t.FlTrocaAceita)
                .IsRequired();

            Property(t => t.FlTrocaRejeitada)
                .IsRequired();

            Property(t => t.DtTrocaAceita);


            Property(t => t.DtTrocaProposta);



            Property(t => t.DtTrocaRealizada);


            Property(t => t.DtTrocaRejeitada);


            HasRequired(t => t.Produto)
                .WithMany(p => p.Trocas)
                .HasForeignKey(t => t.IdProdutoProposto)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Produto)
                .WithMany(p => p.Trocas)
                .HasForeignKey(t => t.IdProdutoSujeito)
                .WillCascadeOnDelete(false);
        }

    }
}
