using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            //Tabela
            ToTable("Produtos");

            //Chave Primária
            HasKey(p => p.ProdutoId);

            //Propriedades
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Detalhes)
                .IsRequired()
                .HasMaxLength(1500);


            Property(p => p.OutrasCategorias)
                .HasMaxLength(50);


            Property(p => p.ProdutoInteresse)
                .HasMaxLength(200);

            Property(p => p.DataCriacao)
                .IsRequired();

            Property(p => p.DataAlteracao)
                .IsRequired();

            Property(p => p.UsuarioId)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            //Relacionamentos
            HasRequired(p => p.SubCategoria)
                .WithMany(s => s.Produtos)
                .HasForeignKey(p => p.SubCategoriaId)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Usuario)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p => p.UsuarioId)
                .WillCascadeOnDelete(true);
        }
    }
}
