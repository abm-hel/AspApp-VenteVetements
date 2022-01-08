using AspApp_VenteVetements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspApp_VenteVetements.Controllers
{
    [AllowAnonymous]
    public class InscriptionController : Controller
    {
        // GET: Inscription
        public ActionResult InscrireUtilisateur()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InscrireUtilisateur(Utilisateur utilisateur)
        {
            using(ContexteBD baseDonnes = new ContexteBD())
            {
                if(baseDonnes.Utilisateurs.Any(x => x.adresseMail == utilisateur.adresseMail))
                {
                    ViewBag.UtilisateurExisteDejaMessage = "Cette Adresse Email existe déjà ";
                    return View("InscrireUtilisateur", utilisateur);
                }

                else
                {
                    utilisateur.statutId = 2;
                    baseDonnes.Utilisateurs.Add(utilisateur);
                    baseDonnes.SaveChanges();
                }
            }
            ModelState.Clear();
            ViewBag.InscriptionAvecSuccesMessage = "Vous êtes désormais inscrit(e).";
            return View("InscrireUtilisateur", new Utilisateur());
        }
    }
}