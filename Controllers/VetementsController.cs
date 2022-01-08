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
    [Authorize]
    public class VetementsController : Controller
    {
        private ContexteBD db = new ContexteBD();

        // GET: Vetements
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View(db.Vetements.ToList());
        }

        // GET: Vetements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vetement vetement = db.Vetements.Find(id);
            if (vetement == null)
            {
                return HttpNotFound();
            }
            return View(vetement);
        }

        // GET: Vetements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vetements/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,marque,prix,couleur,taille")] Vetement vetement)
        {
            if (ModelState.IsValid)
            {
                db.Vetements.Add(vetement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vetement);
        }

        // GET: Vetements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vetement vetement = db.Vetements.Find(id);
            if (vetement == null)
            {
                return HttpNotFound();
            }
            return View(vetement);
        }

        // POST: Vetements/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,marque,prix,couleur,taille")] Vetement vetement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vetement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vetement);
        }

        // GET: Vetements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vetement vetement = db.Vetements.Find(id);
            if (vetement == null)
            {
                return HttpNotFound();
            }
            return View(vetement);
        }

        // POST: Vetements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vetement vetement = db.Vetements.Find(id);
            db.Vetements.Remove(vetement);
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
