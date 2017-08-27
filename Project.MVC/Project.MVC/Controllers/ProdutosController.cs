﻿using Microsoft.AspNet.Identity;
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
        private readonly IPerguntaAppService _perguntasAppService;
        private readonly IRespostaAppService _respostaAppServie;

        public ProdutosController(IProdutoAppService produtoAppService, 
                                        ICategoriaAppService categoriaAppService,
                                                ISubCategoriaAppService subCategoriaAppService,
                                                    IProdutoImagemAppService produtoImagemAppService,
                                                    IPerguntaAppService perguntaAppService,
                                                    IRespostaAppService respostaAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;
            _subCategoriaAppService = subCategoriaAppService;
            _produtoImagemAppService = produtoImagemAppService;
            _perguntasAppService = perguntaAppService;
            _respostaAppServie = respostaAppService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult MeusProdutos()
        {
            var produtoViewModels = _produtoAppService.GetByUsuario(User.Identity.GetUserId());
            return View(produtoViewModels);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Novo()
        {
            ViewBag.Categorias = new SelectList(_categoriaAppService.GetAll(), "CategoriaId", "Nome");
            ViewBag.SubCategorias = new SelectList(_subCategoriaAppService.GetAll(), "SubCategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Novo(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                produtoViewModel.UsuarioId = User.Identity.GetUserId();
                var produtoAdicionado = _produtoAppService.Add(produtoViewModel);
                return Json(produtoAdicionado);
            }
            ViewBag.Categorias = new SelectList(_categoriaAppService.GetAll(), "CategoriaId", "Nome");
            ViewBag.SubCategorias = new SelectList(_subCategoriaAppService.GetAll(), "SubCategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public ActionResult Editar(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                produtoViewModel.UsuarioId = User.Identity.GetUserId();
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
            produtoViewModel.PerguntaUsuarioViewModels = _perguntasAppService.GetByProduto(id.Value);
            ViewBag.Usuario = _usuarioAppService.GetById(produtoViewModel.UsuarioId);
            ViewBag.Produto = produtoViewModel;
            return View(produtoViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ModalCriarPergunta(int produtoId)
        {
            var produto = _produtoAppService.GetById(produtoId);
            ViewBag.Produto = produto;
            return PartialView("_CriacaoPergunta", new PerguntaViewModel { ProdutoId = produtoId });
        }

        [HttpPost]
        [Authorize]
        public ActionResult CriarPergunta(PerguntaViewModel perguntaViewModel)
        {
            if (ModelState.IsValid)
            {
                perguntaViewModel.UsuarioId = User.Identity.GetUserId();
                var perguntaAdicionado = _perguntasAppService.Add(perguntaViewModel);
                ViewBag.Produto = _produtoAppService.GetById(perguntaAdicionado.ProdutoId);
                return PartialView("_DescricaoPergunta", perguntaAdicionado);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Authorize]
        public ActionResult CriarResposta(RespostaViewModel respostaViewModel)
        {
            var pergunta = _perguntasAppService.GetById(respostaViewModel.RespostaId);
            var produto = _produtoAppService.GetById(pergunta.ProdutoId);
            if (produto.UsuarioId != User.Identity.GetUserId())
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ViewBag.Usuario = _usuarioAppService.GetById(User.Identity.GetUserId());
            ViewBag.Produto = produto;
            var respostaAdicionada = _respostaAppServie.Add(respostaViewModel);
            return PartialView("_DescricaoResposta", respostaAdicionada);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ModalEditarResposta(int respostaId)
        {
            var resposta = _respostaAppServie.GetById(respostaId);
            return PartialView("_EditarResposta", resposta);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditarResposta(RespostaViewModel respostaViewModel)
        {
            if (ModelState.IsValid)
            {
                _respostaAppServie.Update(respostaViewModel);
                var resposta = _respostaAppServie.GetById(respostaViewModel.RespostaId);
                var pergunta = _perguntasAppService.GetById(respostaViewModel.RespostaId);
                var produto = _produtoAppService.GetById(pergunta.ProdutoId);
                if (produto.UsuarioId != User.Identity.GetUserId())
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                ViewBag.Usuario = _usuarioAppService.GetById(User.Identity.GetUserId());
                ViewBag.Produto = produto;
                return PartialView("_DescricaoResposta", resposta);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Authorize]
        public ActionResult BuscarSubCategorias(int? categoriaId)
        {
            if (categoriaId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var subCategorias = _subCategoriaAppService.GetByCategoria(categoriaId.Value);
            return Json(subCategorias, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Authorize]
        public ActionResult ProporTroca(int produtoPropostoId, int produtoSujeitoId, TrocaViewModel trocaViewModel)
        {
            if (ModelState.IsValid)
            {

                
                trocaViewModel.IdProdutoProposto = produtoPropostoId;
                trocaViewModel.IdProdutoSujeito = produtoSujeitoId;
                trocaViewModel.FlTrocaProposta = true;
                trocaViewModel.FlTrocaAceita = false;
                trocaViewModel.FlTrocaRealizada = false;
                
                var trocaproposta = _trocaAppService.Add(trocaViewModel);
                

            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        [Authorize]
        public ActionResult AceitarTroca(int produtoPropostoId, int produtoSujeitoId, TrocaViewModel trocaViewModel)
        {
            if (ModelState.IsValid)
            {


                trocaViewModel.IdProdutoProposto = produtoPropostoId;
                trocaViewModel.IdProdutoSujeito = produtoSujeitoId;
                trocaViewModel.FlTrocaProposta = true;
                trocaViewModel.FlTrocaAceita = true;
                trocaViewModel.FlTrocaRealizada = false;
                
                _trocaAppService.Update(trocaViewModel);


            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        [Authorize]
        public ActionResult ConfirmarTroca(int produtoPropostoId, int produtoSujeitoId, TrocaViewModel trocaViewModel)
        {
            if (ModelState.IsValid)
            {


                trocaViewModel.IdProdutoProposto = produtoPropostoId;
                trocaViewModel.IdProdutoSujeito = produtoSujeitoId;
                trocaViewModel.FlTrocaProposta = true;
                trocaViewModel.FlTrocaAceita = true;
                trocaViewModel.FlTrocaRealizada = true;

                 _trocaAppService.Update(trocaViewModel);


            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}