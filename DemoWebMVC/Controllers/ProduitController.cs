using DemoWebMVC.DataAcces;
using DemoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebMVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProduitController : Controller
    {

        IRepository<Produit> rep = new EFRepository<Produit>();

        // GET: Produit
        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<Produit> produits = rep.Lister();
            return View(produits);
        }

        // GET: Produit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            PeuplerCategoryesViewData();
            return View();
        }

        private void PeuplerCategoryesViewData()
        {
            ViewData["idCategorie"] = new SelectList((new EFRepository<Categorie>()).Lister(), "Id", "Nom");
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(Produit p)
        {
            try
            {
                rep.Ajouter(p);

                return RedirectToAction("Index");
            }
            catch
            {
                PeuplerCategoryesViewData();
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            Produit p = rep.Trouver(id);
            PeuplerCategoryesViewData();
            return View(p);
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(Produit p)
        {
            try
            {
                rep.Modifier(p);

                return RedirectToAction("Index");
            }
            catch
            {
                PeuplerCategoryesViewData();
                return View();
            }
        }

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            Produit p = rep.Trouver(id);
            return View(p);
        }

        // POST: Produit/Delete/5
        [HttpPost]
        [ActionName("delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                rep.suprimer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
