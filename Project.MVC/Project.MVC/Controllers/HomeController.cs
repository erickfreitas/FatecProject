using Project.Application.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly ICategoriaAppService _categoriaAppService;

        public HomeController(IProdutoAppService produtoAppService,
                                ICategoriaAppService categoriaAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;
        }

        public ActionResult Index()
        {
            ViewBag.Produtos = _produtoAppService.GetAll();            
            return View();
        }

        [HttpGet]
        public ActionResult CarregarCategorias()
        {
            var categorias = _categoriaAppService.GetCategoriasAtivas();
            return View("_MenuCategorias", categorias);
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