using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Utilisateur
    {
        public int id { get; set; }
        public int statutId { get; set; }

        [Required]
        [DisplayName("Nom complet")]
        public string nom { get; set; }

        [Required]
        [DisplayName("Adresse Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Cette adresse Email est invalide")]
        public string adresseMail { get; set; }
        
        [Required]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string motDePasse { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
        public virtual Statut Statut { get; set; }

    }
}