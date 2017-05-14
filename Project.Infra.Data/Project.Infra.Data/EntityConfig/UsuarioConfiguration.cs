using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            //Tabela
            ToTable("Usuarios");

            //Chave Primária
            HasKey(u => u.UsuarioId);

            //Propriedades
            Property(u => u.UsuarioId)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            Property(u => u.Nome)
                .IsRequired();

            Property(u => u.Sobrenome)
                .IsOptional();

            Property(u => u.Rg)
                .IsRequired()
                .HasMaxLength(15);

            Property(u => u.Cpf)
                .IsRequired()
                .HasMaxLength(15); ;

            Property(u => u.Email)
                .IsRequired();

            Property(u => u.EmailConfirmado)
                .IsRequired();

            Property(u => u.Telefone)
                .IsOptional();

            Property(u => u.TelefoneConfirmado)
                .IsRequired();

            Property(u => u.DoisFatoresAtivados)
                .IsRequired();

            Property(u => u.HashDeSenha)
                .IsRequired();

            Property(u => u.CarimboDeSeguranca)
                .IsRequired();

            Property(u => u.BloqueioAtivo)
                .IsRequired();

            Property(u => u.FimDeBloqueio)
                .HasColumnType("datetime2")
                .IsOptional();

            Property(u => u.DataCriacao)
                .IsRequired();

            Property(u => u.DataAlteracao)
                .IsRequired();
        }
    }
}
