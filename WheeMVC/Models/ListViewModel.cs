using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheeMVC.Models
{
    public class ListViewModel
    {
        [Display(Name="Nom")]
        public string nom { get; set; }
        
        [Display(Name = "Prenom")]
        public string prenom { get; set; }
        
        [Display(Name = "Mail")]
        public string mail { get; set; }
        [Display(Name = "Genre")]
        public string genre { get; set; }
        [Display(Name = "Contact")]
        public string contact { get; set; }
        [Display(Name = "Adresse")]
        public string adresse { get; set; }
        [Display(Name = "Mot de passe")]
        public string mot_de_passe { get; set; }
        [Display(Name = "Img")]
        public string img { get; set; }

        [Display(Name = "ImgP")]
        public string imgP { get; set; }
        [Display(Name = "Nombre de passager")]
        public string nbpassager { get; set; }
        [Display(Name = "Point de départ")]
        public string pointdepart { get; set; }
        [Display(Name = "Point d'arriver")]
        public string pointarrive { get; set; }
        [Display(Name = "Date voyage")]
        public string datecov { get; set; }
        [Display(Name = "Heure de départ")]
        public string heuredepart { get; set; }
        [Display(Name = "Type d'annonce")]
        public string type_annonce { get; set; }
        [Display(Name = "Tarif")]
        public string tarif { get; set; }
        [Display(Name = "Text Button")]
        public string textbtn { get; set; }
    }
}