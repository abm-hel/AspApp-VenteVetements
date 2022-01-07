using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Vetement
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string marque { get; set; }
        public float prix { get; set; }
        public string couleur { get; set; }
        public string taille { get; set; }

        public virtual ICollection<VetementCommande> VetementCommandes { get; set; }
    }
}