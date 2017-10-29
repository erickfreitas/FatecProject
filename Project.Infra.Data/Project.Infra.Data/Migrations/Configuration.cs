using Project.Domain.Entities;
using Project.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Project.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Project.Infra.Data.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Project.Infra.Data.Context.ProjectContext";
        }

        //protected override void Seed(ProjectContext context)
        //{
        //    context.Categorias.AddRange(new List<Categoria>
        //    {
        //        new Categoria
        //        {
        //            Nome = "M�veis",
        //            SubCategorias = new List<SubCategoria>
        //            {
        //                new SubCategoria { Nome = "Sof�"},
        //                new SubCategoria { Nome = "Mesa"},
        //                new SubCategoria { Nome = "Arm�rio"},
        //                new SubCategoria { Nome = "Guarda Roupa"},
        //                new SubCategoria { Nome = "Cama"}
        //            }
        //        },
        //        new Categoria
        //        {
        //            Nome = "Eletr�nicos",
        //            SubCategorias = new List<SubCategoria>
        //            {
        //                new SubCategoria { Nome = "Televis�o"},
        //                new SubCategoria { Nome = "Home Theater"},
        //                new SubCategoria { Nome = "Aparelho de Som"},
        //                new SubCategoria { Nome = "DVD"}
        //            }
        //        },
        //        new Categoria
        //        {
        //            Nome = "Inform�tica",
        //            SubCategorias = new List<SubCategoria>
        //            {
        //                new SubCategoria { Nome = "Computador"},
        //                new SubCategoria { Nome = "Notebook"},
        //                new SubCategoria { Nome = "Smartphone"},
        //                new SubCategoria { Nome = "Tablet"},
        //                new SubCategoria { Nome = "Impressora"}
        //            }
        //        }
        //    });
        //    context.SaveChanges();
        //}
    }
}
