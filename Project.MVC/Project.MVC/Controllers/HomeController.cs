using Project.Application.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly ITrocaAppService _trocaAppService;
        private readonly ICategoriaAppService _categoriaAppService;

        public HomeController(IProdutoAppService produtoAppService,
                                ITrocaAppService trocaAppService,
                                    ICategoriaAppService categoriaAppService)
        {
            _produtoAppService = produtoAppService;
            _trocaAppService = trocaAppService;
            _categoriaAppService = categoriaAppService;
        }

        public ActionResult Index()
        {
            ViewBag.Produtos = _produtoAppService.GetAll();
            ViewBag.NumeroTrocas = _trocaAppService.GetByFilter(t => t.FlTrocaRealizada == true).Count();
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


        [HttpGet]
        public ActionResult Pesquisa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pesquisa(string texto)
        {
            return View(_produtoAppService.GetAll().Where(x => x.Nome.Contains(texto)).OrderBy(x => x.Nome));
        }
    }
}