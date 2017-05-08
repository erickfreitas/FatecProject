using Microsoft.AspNet.Identity.EntityFramework;
using Project.Infra.CrossCutting.Identity.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace Project.Infra.CrossCutting.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public IdentityContext() : base("ProjectConnection2", throwIfV1Schema: false)
        {
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Id).HasColumnName("UsuarioId");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).HasColumnName("Email");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.EmailConfirmed).HasColumnName("EmailConfirmado");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PhoneNumber).HasColumnName("Telefone");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PhoneNumberConfirmed).HasColumnName("TelefoneConfirmado");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.TwoFactorEnabled).HasColumnName("DoisFatoresAtivados");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PasswordHash).HasColumnName("HashDeSenha");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.SecurityStamp).HasColumnName("CarimboDeSeguranca");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.LockoutEnabled).HasColumnName("BloqueioAtivo");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.LockoutEndDateUtc).HasColumnName("FimDeBloqueio");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.AccessFailedCount).HasColumnName("ContagemFalhaDeAcesso");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).HasColumnName("UsuarioNome");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuarioRoles");
            modelBuilder.Entity<IdentityUserRole>().Property(i => i.UserId).HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityUserRole>().Property(i => i.RoleId).HasColumnName("RoleId");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsuarioClaims");
            modelBuilder.Entity<IdentityUserClaim>().Property(i => i.Id).HasColumnName("UsuarioClaimId");
            modelBuilder.Entity<IdentityUserClaim>().Property(i => i.UserId).HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityUserClaim>().Property(i => i.ClaimType).HasColumnName("Tipo");
            modelBuilder.Entity<IdentityUserClaim>().Property(i => i.ClaimValue).HasColumnName("Valor");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuarioLogins");
            modelBuilder.Entity<IdentityUserLogin>().Property(i => i.LoginProvider).HasColumnName("Provedor");
            modelBuilder.Entity<IdentityUserLogin>().Property(i => i.ProviderKey).HasColumnName("Chave");
            modelBuilder.Entity<IdentityUserLogin>().Property(i => i.UserId).HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRole>().Property(i => i.Id).HasColumnName("RoleId");
            modelBuilder.Entity<IdentityRole>().Property(i => i.Name).HasColumnName("Nome");
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
