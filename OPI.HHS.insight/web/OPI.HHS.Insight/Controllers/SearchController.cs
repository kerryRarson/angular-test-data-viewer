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
        protected readonly IHHSService _svc;
        public SearchController(IHHSService svc) { _svc = svc; }
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
        public ActionResult SearchByParent()
        {
            return View();
        }
        public ActionResult CaseDetail(string caseNum)
        {
            ViewBag.CaseNumber = caseNum;
            
            return View();
        }

        public ActionResult ReferralDetail(int Id)
        {
            var model = new Models.ReferralModel();
            var r = _svc.GetReferral(Id);
            if (r != null)
            {
                model = new Models.ReferralModel() { 
                ReferralId = Id,
                 LastName = r.LastName,
                 FirstName = r.FirstName,
                 MiddleName = r.MiddleName,
                 Suffix = r.Suffix,
                 DOB = r.DOB,
                 Race = r.Race,
                 Gender = r.Gender,
                 Ethnicity = r.Ethnicity,
                 Source = r.Source
                };
            }
            return View(model);
        }
    }
}