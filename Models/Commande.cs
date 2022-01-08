using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Commande
    {
        public int id { get; set; }
        public int utilisateurId { get; set; }

        public DateTime date { get; set; }
        public string AdresseLivraison { get; set; }

        public virtual Vetement Vetement { get; set; }
        public virtual ICollection<VetementCommande> VetementCommandes { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}