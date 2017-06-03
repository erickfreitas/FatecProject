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

            Property(r => r.Descricao)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(1500);


            HasRequired(r => r.Pergunta)
                .WithOptional(p => p.Resposta);
                

            
               

        }
    }
}
