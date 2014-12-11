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
        public ActionResult CaseDetail(string caseNum)
        {
            ViewBag.CaseNumber = caseNum;
            
            return View();
        }
    }
}