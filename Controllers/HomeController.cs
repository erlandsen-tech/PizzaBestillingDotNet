using System.Linq;
using System.Web.Mvc;
using PizzaBestilling.Models;
using PizzaBestilling.Repo;
using PizzaBestilling.Logic;

namespace PizzaBestilling.Controllers
{
    public class HomeController : Controller
    {
        private IPizzaDbRepo<Kunde> _kundeRepo;
        private IPizzaDbRepo<Pizza> _bestillingRepo;
        private IDBLogic _dbLogic;
        public HomeController()
        {
            this._kundeRepo = new PizzaDbRepo<Kunde>();
            this._bestillingRepo = new PizzaDbRepo<Pizza>();
        }
        public HomeController(IPizzaDbRepo<Kunde> kundeRepo, IPizzaDbRepo<Pizza> bestillingRepo)
        {
            this._kundeRepo = kundeRepo;
            this._bestillingRepo = bestillingRepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Bestilling()
        {
            return View();
        }
        public ActionResult Slett(int Id)
        {
            _bestillingRepo.Delete(Id);
            _bestillingRepo.Save();
            return RedirectToAction("Bestillinger");
        }
        [HttpGet]
        public ActionResult Bestillinger()
        {
            var bestillingView = new BestillingerViewModel
            {
                AlleKunder = _kundeRepo.GetAll().ToList(),
                AlleBestillinger = _bestillingRepo.GetAll().ToList()
            };
            return View(bestillingView);
        }

        public ActionResult TestView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bestill(BestillingViewModel innkommendeBestilling)
        {
            if (ModelState.IsValid)
            {
                this._dbLogic = new DBLogic();
                bool insertOK = this._dbLogic.Bestill(innkommendeBestilling);
                if (insertOK)
                {
                    return RedirectToAction("Bestillinger");
                }
            }
            return View("Bestilling");
        }
    }
}