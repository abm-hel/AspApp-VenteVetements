using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class VetementCommande
    {
        public int id { get; set; }
        public int commandeId { get; set; }
        public int vetementId { get; set; }
     
        public int quantite { get; set; }

        public virtual Commande Commande { get; set; }
        public virtual Vetement Vetement { get; set; }
    }
}