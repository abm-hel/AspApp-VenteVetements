using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspApp_VenteVetements.Models;

namespace AspApp_VenteVetements.Controllers
{
    public class VetementCommandesController : Controller
    {
        private ContexteBD db = new ContexteBD();

        // GET: VetementCommandes
        public ActionResult Index()
        {
            var vetementCommandes = db.VetementCommandes.Include(v => v.Commande).Include(v => v.Vetement);
            return View(vetementCommandes.ToList());
        }

        // GET: VetementCommandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetementCommande vetementCommande = db.VetementCommandes.Find(id);
            if (vetementCommande == null)
            {
                return HttpNotFound();
            }
            return View(vetementCommande);
        }

        // GET: VetementCommandes/Create
        public ActionResult Create()
        {
            ViewBag.commandeId = new SelectList(db.Commandes, "id", "AdresseLivraison");
            ViewBag.vetementId = new SelectList(db.Vetements, "id", "nom");
            return View();
        }

        // POST: VetementCommandes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,commandeId,vetementId,quantite")] VetementCommande vetementCommande)
        {
            if (ModelState.IsValid)
            {
                db.VetementCommandes.Add(vetementCommande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commandeId = new SelectList(db.Commandes, "id", "AdresseLivraison", vetementCommande.commandeId);
            ViewBag.vetementId = new SelectList(db.Vetements, "id", "nom", vetementCommande.vetementId);
            return View(vetementCommande);
        }

        // GET: VetementCommandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetementCommande vetementCommande = db.VetementCommandes.Find(id);
            if (vetementCommande == null)
            {
                return HttpNotFound();
            }
            ViewBag.commandeId = new SelectList(db.Commandes, "id", "AdresseLivraison", vetementCommande.commandeId);
            ViewBag.vetementId = new SelectList(db.Vetements, "id", "nom", vetementCommande.vetementId);
            return View(vetementCommande);
        }

        // POST: VetementCommandes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,commandeId,vetementId,quantite")] VetementCommande vetementCommande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vetementCommande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commandeId = new SelectList(db.Commandes, "id", "AdresseLivraison", vetementCommande.commandeId);
            ViewBag.vetementId = new SelectList(db.Vetements, "id", "nom", vetementCommande.vetementId);
            return View(vetementCommande);
        }

        // GET: VetementCommandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetementCommande vetementCommande = db.VetementCommandes.Find(id);
            if (vetementCommande == null)
            {
                return HttpNotFound();
            }
            return View(vetementCommande);
        }

        // POST: VetementCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VetementCommande vetementCommande = db.VetementCommandes.Find(id);
            db.VetementCommandes.Remove(vetementCommande);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
