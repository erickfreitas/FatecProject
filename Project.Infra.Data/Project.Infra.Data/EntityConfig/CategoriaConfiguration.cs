using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            //Tabela
            ToTable("Categorias");

            //Chave Primária
            HasKey(c => c.CategoriaId);

            //Propriedades
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.MostrarNoMenuInicial)
                .IsRequired();

            Property(c => c.DataCriacao)
                .IsRequired();

            Property(c => c.DataAlteracao)
                .IsRequired();

            //Relacionamentos
            HasMany(c => c.Produtos)
                .WithRequired(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
