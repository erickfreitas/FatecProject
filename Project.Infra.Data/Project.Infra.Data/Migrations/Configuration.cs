using Project.Infra.Data.Context;
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

        protected override void Seed(ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.
        }
    }
}
