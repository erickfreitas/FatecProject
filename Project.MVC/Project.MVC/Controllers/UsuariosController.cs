using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Project.Application.Interfaces;
using Project.Infra.CrossCutting.Identity.Configuration;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly IUsuarioAppService _usuarioAppService;

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

        public UsuariosController(ApplicationUserManager userManager, IUsuarioAppService usuarioAppService)
        {
            _userManager = userManager;
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MeuPerfil()
        {
            var usuario = _usuarioAppService.GetById(User.Identity.GetUserId());
            return View(usuario);
        }
    }
}