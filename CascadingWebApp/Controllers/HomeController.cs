using CascadingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingWebApp.Controllers
{
    public class HomeController : Controller
    {
        TestEntities2 dbEntity = new TestEntities2();
        public ActionResult Index()
        {
            
            ViewBag.countryid = new SelectList(dbEntity.Countries, "CountryId", "County");
            ViewBag.states = new SelectList(new List<countryState>(), "StateId", "State");
            return View();
        }
        public IList<countryState> Getstate(int id)
        {
            return dbEntity.countryStates.Where(m => m.CountryId == id).ToList();
        }

        public JsonResult GetJsonState(int id)
        {

            var stateListt = this.Getstate(Convert.ToInt32(id));
            var statesList = stateListt.Select(m => new SelectListItem()
            {
                Text = m.State,
                Value = m.CountryId.ToString()
            });

            return Json(statesList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}