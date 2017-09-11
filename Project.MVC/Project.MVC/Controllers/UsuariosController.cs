using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Infra.CrossCutting.Identity.Configuration;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ITrocaAppService _trocaAppService;


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
                                            IProdutoAppService produtoAppService,
                                            ITrocaAppService trocaAppService)
        {
            _userManager = userManager;
            _usuarioAppService = usuarioAppService;
            _produtoAppService = produtoAppService;
            _trocaAppService = trocaAppService;
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



            var usuario = _usuarioAppService.GetById(User.Identity.GetUserId());

            var produtosUsuario = _produtoAppService.GetByFilter(p => p.UsuarioId == usuario.UsuarioId).ToList();


            var trocasUsuario = new List<Troca>();

            var meusProdutosOfertados = new List<Produto>();

            var produtoOfertados = new List<Produto>();

            int count = 0;

            foreach (var produtos in produtosUsuario)
            {

                trocasUsuario = _trocaAppService.GetByFilter(t => t.IdProdutoSujeito == produtos.ProdutoId).ToList();

                count++;



                foreach (var trocas in trocasUsuario)
                {
                    meusProdutosOfertados = _produtoAppService.GetByFilter(p => p.UsuarioId == usuario.UsuarioId &&
                   p.ProdutoId == trocas.IdProdutoSujeito &&
                   trocas.FlTrocaProposta == true).ToList();

                    produtoOfertados = _produtoAppService.GetByFilter(p => p.ProdutoId == trocas.IdProdutoProposto).ToList();

                    count++;

                    var meusProdutosOfertadosViewModel = Mapper.Map<List<ProdutoViewModel>>(meusProdutosOfertados);


                    var produtoOfertadosViewModel = Mapper.Map<List<ProdutoViewModel>>(produtoOfertados);

                    var trocasViewModel = Mapper.Map<List<TrocaViewModel>>(trocasUsuario);



                    ViewBag.Trocas = trocasViewModel;

                    ViewBag.MeusProdutosOfertados = meusProdutosOfertadosViewModel;

                    ViewBag.ProdutoOfertados = produtoOfertadosViewModel;
                }

            }
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
            usuarioViewModel.Cep = usuarioViewModel.Cep.Replace("-", "");
            _usuarioAppService.UpdadeInformacao(usuarioViewModel);
            return RedirectToAction("Meuperfil");
        }
    }
}