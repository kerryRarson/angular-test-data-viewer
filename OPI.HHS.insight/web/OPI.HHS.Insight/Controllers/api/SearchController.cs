using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OPI.HHS.Core;
using OPI.HHS.Core.Models;


namespace OPI.HHS.Insight.Controllers.api
{
    public class SearchController : ApiController
    {
        IHHSService _svc;
        public SearchController(IHHSService svc) { _svc = svc; }
        // GET api/<controller>
        [Route("api/search/getstates")]
        public IEnumerable<string> GetStates()
        {
            List<string> rtn = new List<string>();
            rtn = _svc.GetStates().ToList();
            return rtn;
        }

        [HttpPost]
        [Route("api/search/bycity")]
        public IEnumerable<OPI.HHS.Core.Models.AddressSearchResult> SearchByCity(string st, string city)
        {
            var rtn = _svc.SearchByCityState(city, st);
            return rtn;
        }

        [HttpPost]
        [Route("api/search/bycase")]
        public IEnumerable<OPI.HHS.Core.Models.AddressSearchResult> SearchByCaseNumber(int caseNumber)
        {
            
            return _svc.SearchByCase(caseNumber);
        }
        
        [HttpPost]
        [Route("api/search/byname")]
        public IEnumerable<ReferralSearchResult> SearchByName(string lastName)
        {
            
            return _svc.SearchByName(lastName);
        }

        [HttpGet]
        [Route("api/search/countybycase")]
        public string GetCountyByCase(string caseNum)
        {
            
            return _svc.GetCountyByCase(caseNum);
        }
        [HttpGet]
        [Route("api/search/getreferralsbycase")]
        public IEnumerable<ReferralSearchResult> GetReferrals(string caseNum)
        {
            
            return _svc.GetReferralsByCase(caseNum);
        }
        [HttpGet]
        [Route("api/search/getparentsbycase")]
        public IEnumerable<Relationship> GetRelationshipsByCase(string caseNum){
            
            return _svc.GetParentsByCase(caseNum);
        }
        [HttpGet]
        [Route("api/search/getprogramsbycase")]
        public IEnumerable<Program> GetProgramsByCase(string caseNum)
        {
            
            return _svc.GetProgramsByCase(caseNum);
        }

        [HttpGet]
        [Route("api/search/getprogramsbyreferral")]
        public IEnumerable<Program> GetProgramsByReferral(int id)
        {
            return _svc.GetProgramsByReferral(id);
        }

        [HttpGet]
        [Route("api/search/getaddrsbycase")]
        public IEnumerable<AddressSearchResult> GetAddressesByCase(int caseNum)
        {
            return _svc.GetAddressesByCase(caseNum);
        }

        [HttpGet]
        [Route("api/search/getreferral")]
        public ReferralSearchResult GetReferral(int referralId)
        {
            return _svc.GetReferral(referralId);
        }

        [HttpGet]
        [Route("api/search/getaddrsbyreferral")]
        public IEnumerable<AddressSearchResult> GetAddressesByReferral(int id)
        {
            return _svc.GetAddressesByReferral(id);
        }
    }
}