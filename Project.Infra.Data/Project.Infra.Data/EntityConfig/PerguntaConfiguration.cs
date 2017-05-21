using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class PerguntaConfiguration : EntityTypeConfiguration<Pergunta>
    {
        public PerguntaConfiguration()
        {
            //Table
            ToTable("Perguntas");

            //Chave Primária
            HasKey(p => p.PerguntaId);


            Property(p => p.PerguntaId)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            //Propriedades
            Property(p => p.UsuarioId)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(1500);


            HasRequired(p => p.Usuario)
                .WithMany(u => u.Perguntas)
                .HasForeignKey(p => p.UsuarioId);

           HasRequired(pg => pg.Produto)
                .WithMany(p => p.Perguntas)
                .HasForeignKey(pg => pg.ProdutoId);
        }
    }
}
