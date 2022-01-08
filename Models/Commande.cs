using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Commande
    {
        [DisplayName("Numéro de commande")]
        public int id { get; set; }

        [DisplayName("Nom Complet")]
        public int utilisateurId { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime date { get; set; }

        [DisplayName("Adresse de livraison")]
        public string AdresseLivraison { get; set; }
        
        public virtual Vetement Vetement { get; set; }
        public virtual ICollection<VetementCommande> VetementCommandes { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}