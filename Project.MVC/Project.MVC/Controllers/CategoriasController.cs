using Project.Application.Interfaces;
using Project.Application.ViewModels;
using System.Net;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;        
        
        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }
               
        public ActionResult Index()
        {
            return View(_categoriaAppService.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel categoriaViewModel = _categoriaAppService.GetById((int)id);
            if (categoriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaId,Nome")] CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaAppService.Add(categoriaViewModel);
                return RedirectToAction("Index");
            }

            return View(categoriaViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel categoriaViewModel = _categoriaAppService.GetById((int)id);
            if (categoriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,Nome")] CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaAppService.Update(categoriaViewModel);
                return RedirectToAction("Index");
            }
            return View(categoriaViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaViewModel categoriaViewModel = _categoriaAppService.GetById((int)id);
            if (categoriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaViewModel categoriaViewModel = _categoriaAppService.GetById((int)id);
            _categoriaAppService.Remove(categoriaViewModel);
            return RedirectToAction("Index");
        }
    }
}
