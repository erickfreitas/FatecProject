using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Project.Infra.CrossCutting.Identity.Model;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Infra.CrossCutting.Identity.Configuration
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public override Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
            return base.SignInAsync(user, isPersistent, rememberBrowser);
        }
    }
}
