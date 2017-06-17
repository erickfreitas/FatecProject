using Project.Application.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public HomeController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public ActionResult Index()
        {
            var produtos = _produtoAppService.GetAll();
            return View();
        }

        public ActionResult QuemSomos()
        {
            return View();
        }

        public ActionResult PerguntasFrequentes()
        {
            return View();
        }
    }
}