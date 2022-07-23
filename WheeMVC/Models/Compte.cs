using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheeMVC.Models
{
    public class Compte
    {
        [Key]
        public string idCompte { get; set; }
        public string idprofil { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string mail { get; set; }
        public string genre { get; set; }
        public string contact { get; set; }
        public string adresse { get; set; }
        public string mot_de_passe { get; set; }
        public string img { get; set; }


    }
}