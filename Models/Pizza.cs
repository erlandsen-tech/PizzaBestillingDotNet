using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PizzaBestilling.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public int KundeId { get; set; }
        public string PizzaType { get; set; }
        public string Tykkelse { get; set; }
        public int Antall { get; set; }
    }
}