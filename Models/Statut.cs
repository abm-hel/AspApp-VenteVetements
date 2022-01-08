using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Statut
    {
        public int id { get; set; }
        public string nom { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}