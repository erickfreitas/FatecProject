// <auto-generated />
namespace Project.CrossCutting.Identity.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.0-30225")]
    public sealed partial class IdentityMigration : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(IdentityMigration));
        
        string IMigrationMetadata.Id
        {
            get { return "201705241205549_IdentityMigration"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}