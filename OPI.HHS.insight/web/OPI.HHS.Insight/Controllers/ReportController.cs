using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPI.HHS.Core;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Insight.Controllers
{
    public class ReportController : Controller
    {
        protected readonly IHHSService _svc;
        public ReportController(IHHSService svc) { _svc = svc; }
        // GET: Report
        public ActionResult Index()
        {
            ViewBag.Title = "Reports";
            return View();
        }
        public ActionResult City()
        {
            ViewBag.Title = "Report by City";
            return View();
        }
        public ActionResult CaseExtract()
        {
            ViewBag.Title = "Extract by Case#";
            return View();
        }
    }
}