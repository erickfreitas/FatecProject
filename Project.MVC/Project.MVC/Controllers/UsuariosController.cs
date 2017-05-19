using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MeuPerfil()
        {
            return View();
        }
    }
}