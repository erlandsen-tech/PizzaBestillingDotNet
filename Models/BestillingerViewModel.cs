using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaBestilling.Models
{
    public class BestillingerViewModel
    {
        public IList<Pizza> AlleBestillinger { get; set; }
        public IList<Kunde> AlleKunder { get; set; }

    }
}