using AutoMapper;
using Microsoft.AspNet.Identity;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ITrocaAppService _trocaAppService;
        private readonly IUsuarioAppService _usuarioAppService;
        public ProdutosController(IProdutoAppService produtoAppService, 
                                        ICategoriaAppService categoriaAppService,
                                                ISubCategoriaAppService subCategoriaAppService,
                                                    IProdutoImagemAppService produtoImagemAppService,
                                                        IPerguntaAppService perguntaAppService,
                                                            IRespostaAppService respostaAppService,
                                                                ITrocaAppService trocaAppService,
                                                                    IUsuarioAppService usuarioAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;
            _subCategoriaAppService = subCategoriaAppService;
            _produtoImagemAppService = produtoImagemAppService;
            _perguntasAppService = perguntaAppService;
            _respostaAppServie = respostaAppService;
            _trocaAppService = trocaAppService;
            _usuarioAppService = usuarioAppService;

        }

        [HttpGet]
        [Authorize]
        public ActionResult MeusProdutos()
        {
            var produtoViewModels = _produtoAppService.GetByUsuario(User.Identity.GetUserId());

            if (produtoViewModels.Count() != 0)
            {
                foreach (var produtoUsuario in produtoViewModels)
                {
                    var produtoTrocadoAceito = _trocaAppService.GetByFilter(p => (p.IdProdutoSujeito == produtoUsuario.ProdutoId && p.FlTrocaRealizada == true )|| (p.IdProdutoProposto == produtoUsuario.ProdutoId && p.FlTrocaRealizada == true));
                    var produtoTrocadoOferecido = _trocaAppService.GetByFilter(p => (p.IdProdutoSujeito == produtoUsuario.ProdutoId && p.FlTrocaRealizada == true) || (p.IdProdutoProposto == produtoUsuario.ProdutoId && p.FlTrocaRealizada == true));


                    ViewBag.ProdutoTrocadoAceito = produtoTrocadoAceito.Count() != 0 ? produtoTrocadoAceito.FirstOrDefault().IdProdutoSujeito : 0 ;

                    ViewBag.ProdutoTrocadoOferecido = produtoTrocadoOferecido.Count() != 0 ? produtoTrocadoOferecido.FirstOrDefault().IdProdutoProposto : 0;

                    
                }


            }
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

            var produtoTrocado = _trocaAppService.GetByFilter(t => t.IdProdutoProposto == id || t.IdProdutoSujeito == id && t.FlTrocaRealizada == true).ToList();
            var produtoTrocadoViewModel = Mapper.Map<List<TrocaViewModel>>(produtoTrocado);
            ViewBag.ProdutoTrocado = produtoTrocadoViewModel.Count;

            var usuario = _usuarioAppService.GetById(User.Identity.GetUserId());
            if (usuario != null)
            {
                var meusProdutos = _produtoAppService.GetByFilter(p => p.UsuarioId == usuario.UsuarioId).ToList();

                
                foreach (var produtos in meusProdutos)
                {

                    var produtoNegociado = _trocaAppService.GetByFilter(t => t.IdProdutoProposto == produtos.ProdutoId && t.IdProdutoSujeito == id && t.FlTrocaProposta == true).ToList().Count();

                    var meusProdutosViewModel = Mapper.Map<List<ProdutoViewModel>>(meusProdutos);
                    //var produtoNegociadoViewModel = Mapper.Map<List<TrocaViewModel>>(produtoNegociado);

                    ViewBag.MeusProdutos = meusProdutosViewModel;
                    ViewBag.ProdutoNegociado = produtoNegociado;
                }
            }
            var nomeDonoProduto = _usuarioAppService.GetByFilter(u => u.UsuarioId == produtoViewModel.UsuarioId).FirstOrDefault().Nome;
            var sobrenomeDonoProduto = _usuarioAppService.GetByFilter(u => u.UsuarioId == produtoViewModel.UsuarioId).FirstOrDefault().Sobrenome;

            var nomeCompletoDonoProduto = nomeDonoProduto + "" + sobrenomeDonoProduto;
            ViewBag.NomeDonoProduto = nomeCompletoDonoProduto;
            
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
                trocaViewModel.FlTrocaRejeitada = false;
                
                trocaViewModel.DtTrocaAceita = DateTime.Now;
                trocaViewModel.DtTrocaProposta = DateTime.Now;
                trocaViewModel.DtTrocaRealizada = DateTime.Now;
                trocaViewModel.DtTrocaRejeitada = DateTime.Now;

                var trocaproposta = _trocaAppService.Add(trocaViewModel);

                ViewBag.MensagemTroca = "Troca enviada para o usuário.";

            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        [HttpPost]
        [Authorize]
        public ActionResult AceitarTroca(int produtoPropostoId, int produtoSujeitoId, int idTroca, TrocaViewModel trocaViewModel)
        {
            if (ModelState.IsValid)
            {
                //var idTroca = _trocaAppService.GetByFilter(c => c.IdProdutoProposto == produtoPropostoId && c.IdProdutoSujeito == produtoSujeitoId).FirstOrDefault().IdTroca;

                trocaViewModel.IdTroca = idTroca;
                trocaViewModel.IdProdutoProposto = produtoPropostoId;
                trocaViewModel.IdProdutoSujeito = produtoSujeitoId;
                trocaViewModel.FlTrocaProposta = true;
                trocaViewModel.FlTrocaAceita = true;
                trocaViewModel.FlTrocaRealizada = false;
                trocaViewModel.FlTrocaRejeitada = false;

                trocaViewModel.DtTrocaAceita = DateTime.Now;
                trocaViewModel.DtTrocaProposta = DateTime.Now;
                trocaViewModel.DtTrocaRealizada = DateTime.Now;
                trocaViewModel.DtTrocaRejeitada = DateTime.Now;

                _trocaAppService.Update(trocaViewModel);


            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        [HttpPost]
        [Authorize]
        public ActionResult ConfirmarTroca(int produtoPropostoId, int produtoSujeitoId, int idTroca, TrocaViewModel trocaViewModel)
        {
            if (ModelState.IsValid)
            {

                //var idTroca = _trocaAppService.GetByFilter(c => c.IdProdutoProposto == produtoPropostoId).LastOrDefault().IdTroca;

                trocaViewModel.IdTroca = idTroca;
                trocaViewModel.IdProdutoProposto = produtoPropostoId;
                trocaViewModel.IdProdutoSujeito = produtoSujeitoId;
                trocaViewModel.FlTrocaProposta = true;
                trocaViewModel.FlTrocaAceita = true;
                trocaViewModel.FlTrocaRealizada = true;
                trocaViewModel.FlTrocaRejeitada = false;


                trocaViewModel.DtTrocaAceita = DateTime.Now;
                trocaViewModel.DtTrocaProposta = DateTime.Now;
                trocaViewModel.DtTrocaRealizada = DateTime.Now;
                trocaViewModel.DtTrocaRejeitada = DateTime.Now;

                _trocaAppService.Update(trocaViewModel);


            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        [HttpPost]
        [Authorize]
        public ActionResult RejeitarTroca(int produtoPropostoId, int produtoSujeitoId, int idTroca, TrocaViewModel trocaViewModel)
        {
            if (ModelState.IsValid)
            {

                //var idTroca = _trocaAppService.GetByFilter(c => c.IdProdutoProposto == produtoPropostoId).LastOrDefault().IdTroca;

                trocaViewModel.IdTroca = idTroca;
                trocaViewModel.IdProdutoProposto = produtoPropostoId;
                trocaViewModel.IdProdutoSujeito = produtoSujeitoId;
                trocaViewModel.FlTrocaProposta = true;
                trocaViewModel.FlTrocaAceita = false;
                trocaViewModel.FlTrocaRealizada = false;
                trocaViewModel.FlTrocaRejeitada = true;

                trocaViewModel.DtTrocaAceita = DateTime.Now;
                trocaViewModel.DtTrocaProposta = DateTime.Now;
                trocaViewModel.DtTrocaRealizada = DateTime.Now;
                trocaViewModel.DtTrocaRejeitada = DateTime.Now;

                _trocaAppService.Update(trocaViewModel);


            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }



        [HttpPost]
        [Authorize]
        public ActionResult Remover(int produtoId)
        {

            var produto = _produtoAppService.GetByFilter(t => t.ProdutoId == produtoId).FirstOrDefault();
            if (ModelState.IsValid)
            {                
                var produtoTroca = _trocaAppService.GetByFilter(t => t.IdProdutoProposto == produtoId || t.IdProdutoSujeito == produtoId).ToList();
                
                foreach (var produtoPorposto in produtoTroca)
                {
                    _trocaAppService.Remove(produtoPorposto);
                }


                _produtoAppService.Remove(produto);
                return RedirectToAction("MeusProdutos", new { @Controller = "Produtos"});
            }
            return View(produto);
        }

    }
}