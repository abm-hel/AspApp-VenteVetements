using AspApp_VenteVetements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspApp_VenteVetements.Controllers
{
    [AllowAnonymous]

    public class AuthentificationController : Controller
    {
        ContexteBD baseDeDonnees = new ContexteBD(); 
        // GET: Authentification
        public ActionResult Connexion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Connexion(Utilisateur utilisateur)
        {
            var utilisateurExistant = baseDeDonnees.Utilisateurs.Where(x => x.adresseMail == utilisateur.adresseMail && x.motDePasse == utilisateur.motDePasse).Count();
            if(utilisateurExistant !=0)
            {
                FormsAuthentication.SetAuthCookie(utilisateur.adresseMail, false);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                TempData["Msg"] = "L'adresse email ou le mot de passe est incorrect !";
                return View();
            }
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Connexion", "Authentification");
        }

    }
}