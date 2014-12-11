using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPI.HHS.Core;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Insight.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult SearchByCity()
        {
            return View();
        }

        public ActionResult SearchByCase()
        {
            return View();
        }

        public ActionResult SearchByName()
        {
            return View();
        }
        public ActionResult PeopleByAddress(string caseNum)
        {
            ViewBag.CaseNumber = caseNum;
            ViewBag.Line1 = "123 Street";
            //ViewBag.Line2 = line2;
            //ViewBag.City = city;
            //ViewBag.State = st;
            //ViewBag.Zip = zip;

            return View();
        }
    }
}