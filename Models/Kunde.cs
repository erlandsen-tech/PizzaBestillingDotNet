using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaBestilling.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int Telefonnr { get; set; }
    }
}