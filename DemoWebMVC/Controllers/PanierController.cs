using DemoWebMVC.DataAcces;
using DemoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebMVC.Controllers
{
    public class PanierController : Controller
    {
        Commande Panier;

        public ActionResult AjoutAuPanier(int Id)
        {
            IRepository<Produit> rep = new EFRepository<Produit>();
            if (Session["panier"]==null)
            {
                Panier = new Commande() { Date = DateTime.Today, IdClient = 1 };
                Panier.Details = new List<Detail>();
                Panier.Details.Add(new Detail { IdProduit = Id, Produit=rep.Trouver(Id), Quantite = 1 });
                Session["panier"] = Panier;
            }
            else
            {
                Panier = (Commande)Session["panier"];
                if (Panier.Details.Where(d=>d.IdProduit==Id).Count()>0)
                {
                    Panier.Details.Where(d => d.IdProduit == Id).First().Quantite++;
                }
                else
                {
                    Panier.Details.Add(new Detail { IdProduit = Id, Produit = rep.Trouver(Id), Quantite = 1 });
                }
                Session["panier"] = Panier;
            }
            return RedirectToAction("Index");
        }

        public ActionResult CommanderPanier()
        {

            //Initialiser un repository pour les commandes
            IRepository<Commande> repCommande = new EFRepository<Commande>();
            

            //Recuperer du panier depuis Session
           Commande Panier = (Commande)Session["panier"];

            //Ajout du Panier dand les commandes
            repCommande.Ajouter(Panier);

            //Panier a vider
            Session["panier"] = null;

            //Retour aux produits
            return RedirectToAction("Index", "Produit");

        }

        // GET: Panier
        public ActionResult Index()
        {
            if (Session["panier"] != null)
            {
                return View(((Commande)Session["panier"]).Details);
            }
            else
            {
                return View(new List<Detail>());

            }

                
        }

        // GET: Panier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Panier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Panier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Panier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
