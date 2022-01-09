using AspApp_VenteVetements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.ViewModels
{
    public class CommandeViewModel
    {
        public List<Commande> Commandes { get; set; }
        public List<VetementsAchetes> Vetements { get; set; }
    }
}

public class VetementsAchetes
{
    public int Quantite { get; set; }
    public int Commande {get; set;}
    public Vetement InfosVetements { get; set; }

}