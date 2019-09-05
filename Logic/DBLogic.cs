using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaBestilling.Models;
using PizzaBestilling.Repo;

namespace PizzaBestilling.Logic
{
    public class DBLogic : IDBLogic
    {
        private IPizzaDbRepo<Kunde> _kundeRepo;
        private IPizzaDbRepo<Pizza> _bestillingRepo;
        public DBLogic()
        {
            this._kundeRepo = new PizzaDbRepo<Kunde>();
            this._bestillingRepo = new PizzaDbRepo<Pizza>();
        }
        public DBLogic(IPizzaDbRepo<Kunde> kundeRepo, IPizzaDbRepo<Pizza> bestillingRepo)
        {
            _kundeRepo = kundeRepo;
            _bestillingRepo = bestillingRepo;
        }
        public bool Bestill(BestillingViewModel innkommendeBestilling)
        {
            bool success;
            var _kunde = KundeMapping(innkommendeBestilling);
            var checkKunde = GetByNavn(_kunde.Navn);
            if (checkKunde == null)
            {
                success = this._kundeRepo.Insert(_kunde);
                this._kundeRepo.Save();
                if (!success)
                {
                    return success;
                }
            }
            else
            {
                _kunde = checkKunde;
            }
            var _bestilling = BestillingMapping(innkommendeBestilling, _kunde);
            success = this._bestillingRepo.Insert(_bestilling);
            this._bestillingRepo.Save();
            return success;
        }
        private Kunde KundeMapping(BestillingViewModel bestilling)
        {
            var kunde = new Kunde()
            {
                Navn = bestilling.Navn,
                Adresse = bestilling.Adresse,
                Telefonnr = bestilling.Telefonnr
            };
            return kunde;
        }
        private Pizza BestillingMapping(BestillingViewModel bestilling, Kunde kunde)
        {
            var outgoingBestilling = new Pizza()
            {
                PizzaType = bestilling.PizzaType,
                Antall = bestilling.Antall,
                Tykkelse = bestilling.Tykkelse
            };
            outgoingBestilling = KundeIdMapping(outgoingBestilling, kunde);
            return outgoingBestilling;
        }
        private Boolean KundeExists(Kunde kunde)
        {
            if (_kundeRepo.GetAll().Any(k => k.Navn == kunde.Navn))
            {
                return true;
            }
            else return false;
        }
        private Pizza KundeIdMapping(Pizza bestilling, Kunde kunde)
        {
            var thisKunde = GetByNavn(kunde.Navn);
            if (thisKunde != null)
            {
                bestilling.KundeId = thisKunde.Id;
            }
            else
            {
                bestilling.KundeId = kunde.Id;
            }
            return bestilling;
        }

        private Kunde GetByNavn(string Navn)
        {
            var kunder = _kundeRepo.GetAll();
            foreach (Kunde kunde in kunder)
            {
                if (kunde.Navn == Navn)
                {
                    return kunde;
                }
            }
            return null;
        }
    }
}