using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            //Table
            ToTable("Enderecos");

            //Chave Primária
            HasKey(e => e.EnderecoId);

            //Propriedades
            Property(e => e.EnderecoId)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(10);

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(30);

            Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Complemento)
                .IsOptional()
                .HasMaxLength(50);

            Property(e => e.Numero)
                .IsOptional()
                .HasMaxLength(8);

            //Relacionamentos
            HasRequired(e => e.Usuario)
                .WithOptional(u => u.Endereco);
        }
    }
}
