using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBestilling.Models;

namespace PizzaBestilling.Logic
{
    public interface IDBLogic
    {
        bool  Bestill(BestillingViewModel bestillingModel);
    }
}
