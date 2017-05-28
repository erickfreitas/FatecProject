using Project.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Project.Infra.Data.EntityConfig
{
    public class RespostaConfiguration : EntityTypeConfiguration<Resposta>
    {
        public RespostaConfiguration()
        {
            //Table
            ToTable("Respostas");

            //Chave Primária
            HasKey(r => r.RespostaId);

            //Propriedades
            Property(r => r.PerguntaId)
                .HasColumnType("int");

            Property(r => r.Descricao)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(1500);


            Property(r => r.UsuarioId)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            HasRequired(r => r.Pergunta)
                .WithMany(p => p.Respostas)
                .HasForeignKey(r => r.PerguntaId);

            HasRequired(r => r.Usuario)
                .WithMany(u => u.Respostas)
                .HasForeignKey(pg => pg.UsuarioId);

            HasRequired(pg => pg.Produto)
                .WithMany(r => r.Respostas)
                .HasForeignKey(pg => pg.ProdutoId);

            
               

        }
    }
}
