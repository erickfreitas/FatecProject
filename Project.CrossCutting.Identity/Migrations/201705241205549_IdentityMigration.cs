namespace Project.CrossCutting.Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityMigration : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Claims",
            //    c => new
            //        {
            //            ClaimsId = c.Guid(nullable: false),
            //            Nome = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.ClaimsId);

            //CreateTable(
            //    "dbo.ClientesWeb",
            //    c => new
            //        {
            //            ClienteWebId = c.Int(nullable: false, identity: true),
            //            ClientChave = c.String(),
            //            UsuarioId = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.ClienteWebId)
            //    .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
            //    .Index(t => t.UsuarioId);

            //CreateTable(
            //    "dbo.Usuarios",
            //    c => new
            //        {
            //            UsuarioId = c.String(nullable: false, maxLength: 128),
            //            Nome = c.String(),
            //            Sobrenome = c.String(),
            //            Rg = c.String(),
            //            Cpf = c.String(),
            //            ImagemCaminho = c.String(),
            //            DataCriacao = c.DateTime(nullable: false),
            //            DataAlteracao = c.DateTime(nullable: false),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmado = c.Boolean(nullable: false),
            //            HashDeSenha = c.String(),
            //            CarimboDeSeguranca = c.String(),
            //            Telefone = c.String(),
            //            TelefoneConfirmado = c.Boolean(nullable: false),
            //            DoisFatoresAtivados = c.Boolean(nullable: false),
            //            FimDeBloqueio = c.DateTime(),
            //            BloqueioAtivo = c.Boolean(nullable: false),
            //            ContagemFalhaDeAcesso = c.Int(nullable: false),
            //            UsuarioNome = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.UsuarioId)
            //    .Index(t => t.UsuarioNome, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.UsuarioClaims",
                c => new
                {
                    UsuarioClaimId = c.Int(nullable: false, identity: true),
                    UsuarioId = c.String(nullable: false, maxLength: 128),
                    Tipo = c.String(),
                    Valor = c.String(),
                })
                .PrimaryKey(t => t.UsuarioClaimId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);

            CreateTable(
                "dbo.UsuarioLogins",
                c => new
                {
                    Provedor = c.String(nullable: false, maxLength: 128),
                    Chave = c.String(nullable: false, maxLength: 128),
                    UsuarioId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.Provedor, t.Chave, t.UsuarioId })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);

            CreateTable(
                "dbo.UsuarioRoles",
                c => new
                {
                    UsuarioId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UsuarioId, t.RoleId })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    RoleId = c.String(nullable: false, maxLength: 128),
                    Nome = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.RoleId)
                .Index(t => t.Nome, unique: true, name: "RoleNameIndex");

        }

        public override void Down()
        {
            DropForeignKey("dbo.UsuarioRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ClientesWeb", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRoles", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioLogins", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioClaims", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UsuarioRoles", new[] { "RoleId" });
            DropIndex("dbo.UsuarioRoles", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioLogins", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioClaims", new[] { "UsuarioId" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
            DropIndex("dbo.ClientesWeb", new[] { "UsuarioId" });
            DropTable("dbo.Roles");
            DropTable("dbo.UsuarioRoles");
            DropTable("dbo.UsuarioLogins");
            DropTable("dbo.UsuarioClaims");
            DropTable("dbo.Usuarios");
            DropTable("dbo.ClientesWeb");
            DropTable("dbo.Claims");
        }
    }
}
