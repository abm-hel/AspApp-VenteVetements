using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Utilisateur
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string role { get; set; }
        public string adresseMail { get; set; }
        public string motDePasse { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}