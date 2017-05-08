using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Project.Application.ViewModels;
using Project.Infra.CrossCutting.Identity.Configuration;
using Project.Infra.CrossCutting.Identity.Model;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class ContaController : Controller
    {
        public ContaController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // Definindo a instancia UserManager presente no request.
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // Definindo a instancia SignInManager presente no request.
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        [HttpGet]
        public ActionResult Nova()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Nova(RegistrarViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Nome = registerViewModel.Nome, UserName = registerViewModel.Email, Email = registerViewModel.Email };
                var result = await UserManager.CreateAsync(user, registerViewModel.Senha);
                if (result.Succeeded)
                {
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
                    ViewBag.Link = callbackUrl;
                    return View("DisplayEmail");
                }
                AddErrors(result);
            }
            return View(registerViewModel);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}