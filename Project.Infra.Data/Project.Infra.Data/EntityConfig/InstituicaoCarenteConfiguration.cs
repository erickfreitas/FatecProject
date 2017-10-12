using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class InstituicaoCarenteConfiguration : EntityTypeConfiguration<InstituicaoCarente>
    {
        public InstituicaoCarenteConfiguration()
        {
            //Tabela
            ToTable("InstituicoesCarentes");

            //Chave Primária
            HasKey(i => i.InstituicaoCarenteId);

            //Propriedades
            Property(i => i.InstituicaoCarenteId)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            Property(i => i.Nome)
                .IsRequired();

            Property(i => i.Historia)
                .IsRequired()
                .HasMaxLength(500);

            Property(i => i.Missao)
                .HasMaxLength(500)
                .IsRequired();

            Property(i => i.Visao)
                .HasMaxLength(300)
                .IsRequired();

            Property(i => i.Valores)
                .HasMaxLength(300)
                .IsRequired();

            Property(i => i.Equipe)
                .HasMaxLength(300)
                .IsRequired();

            Property(i => i.DataAlteracao)
                .IsOptional();

            Property(i => i.DataCriacao)
                .IsRequired();

            //Relacionamento
            HasRequired(i => i.Usuario)
                .WithOptional(u => u.InstituicaoCarente)
                .WillCascadeOnDelete(true);
        }
    }
}
