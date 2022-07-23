
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WheeMVC.Models
{
    public class AnnonceCovoiturage
    {
        [Key]
        public string idCov { get; set; }
        public string nbpassager { get; set; }
        public string pointdepart { get; set; }
        public string pointarrive { get; set; }
        public string datecov { get; set; }
        public string heuredepart { get; set; }
        public string type_annonce { get; set; }
        public string tarif { get; set; }
        public string textbtn { get; set; }


    }
}