using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class ProdutoImagemConfiguration : EntityTypeConfiguration<ProdutoImagem>
    {
        public ProdutoImagemConfiguration()
        {
            //Tabela
            ToTable("ProdutoImagens");

            //Chave Primária
            HasKey(i => i.ProdutoImagemId);

            //Propriedades
            Property(i => i.Caminho)
                .IsRequired();

            Property(i => i.Destaque)
                .IsRequired();

            //Relacionamentos
            HasRequired(i => i.Produto)
                .WithMany(p => p.ProdutoImagens)
                .HasForeignKey(i => i.ProdutoId)
                .WillCascadeOnDelete(true);
        }
    }
}
