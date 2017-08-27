using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Infra.CrossCutting.Identity.Configuration;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IProdutoAppService _produtoAppService;

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

        public UsuariosController(ApplicationUserManager userManager,
                                        IUsuarioAppService usuarioAppService,
                                            IProdutoAppService produtoAppService)
        {
            _userManager = userManager;
            _usuarioAppService = usuarioAppService;
            _produtoAppService = produtoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult MeuPerfil()
        {
            var perfil = _usuarioAppService.GetPerfilById(User.Identity.GetUserId());
            ViewBag.Produtos = _produtoAppService.GetByUsuario(User.Identity.GetUserId());
            return View(perfil);
        }

        [HttpGet]
        public ActionResult Perfil(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var perfil = _usuarioAppService.GetPerfilById(id);
            ViewBag.Produtos = _produtoAppService.GetByUsuario(id);
            return View(perfil);
        }

        [HttpPost]
        [Authorize]
        public ActionResult NovaImagem(HttpPostedFileBase imagem, string usuarioId)
        {
            if (imagem == null || usuarioId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (!usuarioId.Equals(User.Identity.GetUserId()))
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            var usuarioImagem = new UsuarioImagemViewModel(imagem, usuarioId);
            _usuarioAppService.AdicionarImagem(usuarioImagem);
            imagem.SaveAs(Server.MapPath(usuarioImagem.ImagemCaminho));
            return Json("success", string.Format("A imagem {0} foi cadastrada com sucesso!", imagem.FileName));
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoverImagem(string key)
        {
            if (key == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (!key.Equals(User.Identity.GetUserId()))
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            var usuario = _usuarioAppService.GetById(key);
            _usuarioAppService.RemoverImagem(key);
            if (System.IO.File.Exists(Server.MapPath(usuario.ImagemCaminho)))
            {
                System.IO.File.Delete(Server.MapPath(usuario.ImagemCaminho));
            }
            return Json("success", "A imagem foi removida com sucesso!");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditarInformacao(UsuarioInformacaoViewModel usuarioViewModel)
        {
            _usuarioAppService.UpdadeInformacao(usuarioViewModel);
            return RedirectToAction("Meuperfil");
        }
    }
}