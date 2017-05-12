using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class ClienteWebConfiguration : EntityTypeConfiguration<ClienteWeb>
    {
        public ClienteWebConfiguration()
        {
            //Tabela
            ToTable("ClientesWeb");

            //Chave Primária
            HasKey(c => c.ClienteWebId);

            //Propriedade
            Property(c => c.ClientChave)
                .IsRequired();

            Property(c => c.UsuarioId)
                 .HasMaxLength(128)
                .HasColumnType("nvarchar");

            //Relationships
            HasRequired(c => c.Usuario)
                .WithMany(u => u.ClientesWeb)
                .HasForeignKey(c => c.UsuarioId)
                .WillCascadeOnDelete(true);
        }
    }
}
