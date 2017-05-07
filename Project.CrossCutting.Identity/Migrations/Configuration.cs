using Project.Infra.CrossCutting.Identity.Context;
using Project.Infra.CrossCutting.Identity.Model;
using System.Data.Entity.Migrations;

namespace Project.CrossCutting.Identity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Project.Infra.CrossCutting.Identity.Context.IdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Project.Infra.CrossCutting.Identity.Context.IdentityContext";
        }

        protected override void Seed(IdentityContext context)
        {
            //  This method will be called after migrating to the latest version.
            //context.Users.AddOrUpdate(new ApplicationUser
            //{
            //    Nome = "Administrador",
            //    Sobrenome = "Quero Trocas",                
            //});
        }
    }
}
