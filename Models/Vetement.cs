using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Vetement
    {
        public int id { get; set; }
        [DisplayName("Vêtement")]
        public string nom { get; set; }
        [DisplayName("Marque")]
        public string marque { get; set; }
        [DisplayName("Prix")]
        public float prix { get; set; }
        [DisplayName("Couleur")]
        public string couleur { get; set; }
        [DisplayName("Taille")]
        public string taille { get; set; }

        public virtual ICollection<VetementCommande> VetementCommandes { get; set; }
    }
}