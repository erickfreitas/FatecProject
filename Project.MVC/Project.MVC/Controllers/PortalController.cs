using Microsoft.AspNet.Identity.Owin;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Infra.CrossCutting.Identity.Configuration;
using Project.Infra.CrossCutting.Identity.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    [Authorize]
    public class PortalController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ISubCategoriaAppService _subCategoriaAppService;
        private readonly IInstituicaoCarenteAppService _instituicaoCarenteAppService;
        private readonly IUsuarioAppService _usuarioAppService;

        public PortalController(ICategoriaAppService categoriaAppService,
                                    ISubCategoriaAppService subCategoriaAppService,
                                        IInstituicaoCarenteAppService instituicaoCarenteAppService,
                                            IUsuarioAppService usuarioAppService,
                                                ApplicationUserManager userManager, 
                                                    ApplicationSignInManager signInManager)
        {
            _categoriaAppService = categoriaAppService;
            _subCategoriaAppService = subCategoriaAppService;
            _instituicaoCarenteAppService = instituicaoCarenteAppService;
            _usuarioAppService = usuarioAppService;
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
            if (subCategorias.Any())
            {
                ViewBag.Message = "Você deve remover todas as Sub-Categorias pertencentes a essa categoria antes de remove-la.";
                return PartialView("_ModalMessage");
            }
            if (_categoriaAppService.PossuiProduto(categoriaId))
            {
                ViewBag.Message = "Você não pode remover essa categoria pois ela possui produtos cadastrados.";
                return PartialView("_ModalMessage");
            }
            var categoria = _categoriaAppService.GetById(categoriaId);
            return PartialView("_ConfirmarDeletarCategoria", categoria);
        }

        [HttpPost]
        public ActionResult RemoverCategoria(int categoriaId)
        {
            var categoria = _categoriaAppService.GetById(categoriaId);
            _categoriaAppService.Remove(categoria);
            return Json(new { response = "Ok" });
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

        [HttpPost]
        public ActionResult ModalRemoverSubCategoria(int subCategoriaId)
        {            
            if (_subCategoriaAppService.PossuiProduto(subCategoriaId))
            {
                ViewBag.Message = "Você não pode remover essa sub-categoria pois ela possui produtos cadastrados.";
                return PartialView("_ModalMessage");
            }
            var subCategoria = _subCategoriaAppService.GetById(subCategoriaId);
            return PartialView("_ConfirmarDeletarSubCategoria", subCategoria);
        }

        [HttpPost]
        public ActionResult RemoverSubCategoria(int subCategoriaId)
        {
            var subCategoria = _subCategoriaAppService.GetById(subCategoriaId);
            _subCategoriaAppService.Remove(subCategoria);
            return Json(new { response = "Ok" });
        }

        [HttpGet]
        public ActionResult InstituicoesCarentes()
        {
            var instituicoesCarentes = _instituicaoCarenteAppService.GetAll();
            return View(instituicoesCarentes);
        }

        [HttpGet]
        public ActionResult NovaInstituicaoCarente()
        {
            return View();
        }

        [HttpPost]
        public  async Task<ActionResult> NovaInstituicaoCarente(RegistrarInstituiçãoCarenteViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Nome = registerViewModel.Nome, Sobrenome = registerViewModel.Sobrenome, UserName = registerViewModel.Email, Email = registerViewModel.Email, Rg = registerViewModel.Rg, Cpf = registerViewModel.Cpf };
                var result = await UserManager.CreateAsync(user, registerViewModel.Senha);
                if (result.Succeeded)
                {
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    await UserManager.ConfirmEmailAsync(user.Id, code);
                    await UserManager.SendEmailAsync(user.Id, "Sua conta foi cadastrada no sistema Quero Trocar!", $"Usuário: {user.Email}  Senha: {registerViewModel.Senha}");
                    _instituicaoCarenteAppService.Add(registerViewModel, user.Id);
                    return RedirectToAction("InstuicoesCarentes", "Portal");
                }
            }
            return View(registerViewModel);
        }

        [HttpGet]
        public ActionResult DetalhesInstituicaoCarente(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var instituicaoCarente = _instituicaoCarenteAppService.GetById(id);
            if (instituicaoCarente == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            var usuario = _usuarioAppService.GetPerfilById(id);
            ViewBag.InstituicaoCarente = instituicaoCarente;
            return View(usuario);
        }
    }
}