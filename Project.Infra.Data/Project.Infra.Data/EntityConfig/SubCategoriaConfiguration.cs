using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class SubCategoriaConfiguration : EntityTypeConfiguration<SubCategoria>
    {
        public SubCategoriaConfiguration()
        {
            //Tabela
            ToTable("SubCategorias");

            //Chave Primária
            HasKey(s => s.SubCategoriaId);

            //Propriedades
            Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(30);

            Property(s => s.DataCriacao)
                .IsRequired();

            Property(p => p.DataAlteracao)
                .IsRequired();

            //Relacionamentos
            HasRequired(s => s.Categoria)
                .WithMany(c => c.SubCategorias)
                .HasForeignKey(s => s.CategoriaId)
                .WillCascadeOnDelete(false);
        }
    }
}
