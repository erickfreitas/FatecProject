using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Infra.CrossCutting.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DataAlteracao = DateTime.Now;
            DataCriacao = DateTime.Now;
        }
        //Propriedades do Usuário do Domínio
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //userIdentity.AddClaim(new Claim("CompanyId", Convert.ToString(CompanyId)));
            //userIdentity.AddClaim(new Claim("DisplayName", Convert.ToString(DisplayName)));
            // Add custom user claims here
            return userIdentity;
        }
    }
}
