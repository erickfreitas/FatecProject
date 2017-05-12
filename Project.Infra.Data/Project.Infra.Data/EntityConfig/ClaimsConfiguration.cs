using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class ClaimsConfiguration : EntityTypeConfiguration<Claims>
    {
        public ClaimsConfiguration()
        {
            //Tabela
            ToTable("Claims");

            //Chave Primária
            HasKey(c => c.ClaimsId);

            //Propriedades
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
