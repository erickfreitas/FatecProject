using Project.Application.Interfaces;
using Project.Application.ViewModels;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ISubCategoriaAppService _subCategoriaAppService;
        private readonly IProdutoImagemAppService _produtoImagemAppService;

        public ProdutosController(IProdutoAppService produtoAppService, 
                                        ICategoriaAppService categoriaAppService,
                                                ISubCategoriaAppService subCategoriaAppService,
                                                    IProdutoImagemAppService produtoImagemAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;
            _subCategoriaAppService = subCategoriaAppService;
            _produtoImagemAppService = produtoImagemAppService;
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
                var produtoAdicionado = _produtoAppService.Add(produtoViewModel);
                return Json(produtoAdicionado);
            }
            ViewBag.Categorias = new SelectList(_categoriaAppService.GetAll(), "CategoriaId", "Nome");
            ViewBag.SubCategorias = new SelectList(_subCategoriaAppService.GetAll(), "SubCategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult NovaImagem(HttpPostedFileBase imagem, int? produtoId)
        {
            if (imagem == null || produtoId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var produtoImagem = new ProdutoImagemViewModel(imagem, produtoId.Value);
            _produtoImagemAppService.Add(produtoImagem);
            imagem.SaveAs(Server.MapPath(produtoImagem.Caminho));
            return Json("success", string.Format("A imagem {0} foi cadastrada com sucesso!", imagem.FileName));
        }

        [HttpPost]
        public ActionResult RemoverImagem(int? key)
        {
            if (key == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var produtoImagem = _produtoImagemAppService.GetById(key.Value);
            _produtoImagemAppService.Remove(key.Value);
            if (System.IO.File.Exists(Server.MapPath(produtoImagem.Caminho)))
            {
                System.IO.File.Delete(Server.MapPath(produtoImagem.Caminho));
            }
            return Json("success", "A imagem foi removida com sucesso!");
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ViewBag.Categorias = new SelectList(_categoriaAppService.GetAll(), "CategoriaId", "Nome");
            ViewBag.SubCategorias = new SelectList(_subCategoriaAppService.GetAll(), "SubCategoriaId", "Nome");
            var produtoViewModel = _produtoAppService.GetById(id.Value);
            return View(produtoViewModel);
        }

        [HttpPost]
        public ActionResult Editar(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoAppService.Update(produtoViewModel);
                return RedirectToAction("Editar", new { @Controller = "Produtos", @Id = produtoViewModel.ProdutoId });
            }
            return View(produtoViewModel);
        }

        [HttpGet]
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var produtoViewModel = _produtoAppService.GetById(id.Value);
            return View(produtoViewModel);
        }

        public ActionResult BuscarSubCategorias(int? categoriaId)
        {
            if (categoriaId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var subCategorias = _subCategoriaAppService.GetByCategoria(categoriaId.Value);
            return Json(subCategorias, JsonRequestBehavior.AllowGet);
        }
    }
}