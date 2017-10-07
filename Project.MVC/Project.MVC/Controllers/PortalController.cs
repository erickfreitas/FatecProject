using Project.Application.Interfaces;
using Project.Application.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    [Authorize]
    public class PortalController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ISubCategoriaAppService _subCategoriaAppService;

        public PortalController(ICategoriaAppService categoriaAppService,
                                    ISubCategoriaAppService subCategoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
            _subCategoriaAppService = subCategoriaAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Categorias()
        {
            var categorias = _categoriaAppService.GetAll();
            return View(categorias);
        }

        [HttpGet]
        public ActionResult NovaCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovaCategoria(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaAppService.Add(categoriaViewModel);
                return RedirectToAction("Categorias", "Portal");
            }
            return View(categoriaViewModel);
        }

        [HttpGet]
        public ActionResult EditarCategoria(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoria = _categoriaAppService.GetById(id.Value);
            if (categoria == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            ViewBag.Categoria = categoria;
            ViewBag.SubCategorias = _subCategoriaAppService.GetByCategoria(id.Value);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult EditarCategoria(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaAppService.Update(categoriaViewModel);
                ViewBag.Categoria = _categoriaAppService.GetById(categoriaViewModel.CategoriaId);
                ViewBag.SubCategorias = _subCategoriaAppService.GetByCategoria(categoriaViewModel.CategoriaId);
                RedirectToAction("EditarCategoria", "Portal", new { @id = categoriaViewModel.CategoriaId });
            }
            return View(categoriaViewModel);
        }

        [HttpPost]
        public ActionResult ModalRemoverCategoria(int categoriaId)
        {
            var subCategorias = _subCategoriaAppService.GetByCategoria(categoriaId);
            if (!subCategorias.Any())
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult NovaSubCategoria(int? id)
        {
            if (id == null) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ViewBag.Categoria = _categoriaAppService.GetById(id.Value);
            return View(new SubCategoriaViewModel { CategoriaId = id.Value });
        }

        [HttpPost]
        public ActionResult NovaSubCategoria(SubCategoriaViewModel subCategoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _subCategoriaAppService.Add(subCategoriaViewModel);
                return RedirectToAction("EditarCategoria", "Portal", new { @id = subCategoriaViewModel.CategoriaId });
            }
            return View(subCategoriaViewModel);
        }

        [HttpGet]
        public ActionResult EditarSubCategoria(int? id) {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var subCategoria = _subCategoriaAppService.GetById(id.Value);
            if (subCategoria == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            ViewBag.SubCategoria = subCategoria;
            ViewBag.Categoria = _categoriaAppService.GetById(subCategoria.CategoriaId);
            return View(subCategoria);
        }

        [HttpPost]
        public ActionResult EditarSubCategoria(SubCategoriaViewModel subCategoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _subCategoriaAppService.Update(subCategoriaViewModel);
                var subCategoria = _subCategoriaAppService.GetById(subCategoriaViewModel.SubCategoriaId);
                ViewBag.Categoria = _categoriaAppService.GetById(subCategoria.CategoriaId);
                ViewBag.SubCategoria = subCategoria;
                return RedirectToAction("EditarSubCategoria", "Portal", new { @id = subCategoria.SubCategoriaId });
            }
            return View(subCategoriaViewModel);
        }
    }
}