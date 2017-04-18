using Project.Application.Interfaces;
using Project.Application.ViewModels;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ISubCategoriaAppService _subCategoriaAppService;

        public ProdutosController(IProdutoAppService produtoAppService, 
                                        ICategoriaAppService categoriaAppService,
                                                ISubCategoriaAppService subCategoriaAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;
            _subCategoriaAppService = subCategoriaAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var produtoViewModels = _produtoAppService.GetAll();
            return View(produtoViewModels);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            ViewBag.Categorias = new SelectList(_categoriaAppService.GetAll(), "CategoriaId", "Nome");
            ViewBag.SubCategorias = new SelectList(_subCategoriaAppService.GetAll(), "SubCategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Novo(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoAppService.Add(produtoViewModel);
                return RedirectToAction("Index", "Produtos");
            }
            ViewBag.Categorias = new SelectList(_categoriaAppService.GetAll(), "CategoriaId", "Nome");
            ViewBag.SubCategorias = new SelectList(_subCategoriaAppService.GetAll(), "SubCategoriaId", "Nome");
            return View();
        }
    }
}