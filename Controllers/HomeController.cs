using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspApp_VenteVetements.Models;
using AspApp_VenteVetements.ViewModels;


namespace AspApp_VenteVetements.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult AfficherCommandes()
        {
            if (User.Identity.IsAuthenticated == true && User.IsInRole("2"))
            {
                using (ContexteBD baseDonnees = new ContexteBD())
                {
                    var identifiantUtilisateur = (from utilisateur in baseDonnees.Utilisateurs
                                                  where utilisateur.adresseMail == User.Identity.Name
                                                  select utilisateur.id).SingleOrDefault();

                    string nomUtilisateur = (from utilisateur in baseDonnees.Utilisateurs
                                                  where utilisateur.adresseMail == User.Identity.Name
                                                  select utilisateur.nom).SingleOrDefault();

                    ViewBag.messageBienvenue = "Bonjour " + nomUtilisateur;

                    var mesCommandes = (from lesCommandes in baseDonnees.Commandes
                                     where lesCommandes.utilisateurId == identifiantUtilisateur
                                     select lesCommandes).ToList();

                    var mesVetememenCommandes = (from lesVetements in baseDonnees.Vetements
                                                 join lesVetementsCommandes in baseDonnees.VetementCommandes on lesVetements.id equals lesVetementsCommandes.vetementId
                                                 join lesCommandes in baseDonnees.Commandes on lesVetementsCommandes.commandeId equals lesCommandes.id
                                                 where lesCommandes.utilisateurId == identifiantUtilisateur
                                                 select new {lesVetementsCommandes.quantite, lesCommandes.id, lesVetements}).ToList();

                    List<VetementsAchetes> c = new List<VetementsAchetes>();
                    
                    foreach (var vc in mesVetememenCommandes)
                    {
                        VetementsAchetes l = new VetementsAchetes();
                        l.Commande = vc.id;
                        l.InfosVetements = vc.lesVetements;
                        l.Quantite = vc.quantite;
                        c.Add(l);
                    }

                    var monViewModelCommandes = new CommandeViewModel
                    {   Commandes = mesCommandes,
                        Vetements = c
                    };
                    
             

                    return View(monViewModelCommandes);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Authentification");
            }
        }
    }
}