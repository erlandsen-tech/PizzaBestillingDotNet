using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaBestilling.Models
{
    public class BestillingViewModel
    {
        [Required(ErrorMessage = "Du må skrive inn et navn.")]
        public string Navn { get; set; }
        [Required(ErrorMessage = "Vi trenger adressen din")]
        public string Adresse { get; set; }
        [Required(ErrorMessage = "Vi må ha telefonnummeret ditt")]
        public int Telefonnr { get; set; }
        [Required(ErrorMessage = "Må velge hvilken mat du skal ha")]
        public string PizzaType { get; set; }
        [Required(ErrorMessage ="Du må velge tykkelse på bunnen")]
        public string Tykkelse { get; set; }
        [Required(ErrorMessage ="Du må velge antall")]
        public int Antall { get; set; }
    }
}