using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class VetementCommande
    {
        public int id { get; set; }

        [DisplayName("Commande")]
        public int commandeId { get; set; }
        [DisplayName("Vêtement")]
        public int vetementId { get; set; }

        [DisplayName("Quantité")]
        public int quantite { get; set; }

        [DisplayName("Commande")]
        public virtual Commande Commande { get; set; }
        [DisplayName("Vêtement")]
        public virtual Vetement Vetement { get; set; }
    }
}