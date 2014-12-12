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
        // GET api/<controller>
        [Route("api/search/getstates")]
        public IEnumerable<string> GetStates()
        {
            List<string> rtn = new List<string>();
            var svc = new HHSService();
            rtn = svc.GetStates().ToList();
            return rtn;
        }

        // GET api/search?state=xx&?city=yyy
        [HttpGet]
        [Route("api/search/bycity")]
        //[CacheOutput(ClientTimeSpan = 600, ServerTimeSpan = 600)]
        public IEnumerable<OPI.HHS.Core.Models.AddressSearchResult> SearchByCity(string st, string city)
        {
            System.Diagnostics.Debug.WriteLine("searching for {0}, {1}...", city, st);
            var svc = new HHSService();
            var rtn = svc.SearchByCityState(city, st);
            return rtn;
        }

        [HttpGet]
        [Route("api/search/bycase")]
        public IEnumerable<OPI.HHS.Core.Models.AddressSearchResult> SearchByCaseNumber(string caseNumber)
        {
            var svc = new HHSService();
            int num;
            int.TryParse(caseNumber, out num);
            return svc.SearchByCase(num);
        }
        
        [HttpGet]
        [Route("api/search/byname")]
        public IEnumerable<ReferralSearchResult> SearchByName(string lastName)
        {
            var svc = new HHSService();
            return svc.SearchByName(lastName);
        }

        [HttpGet]
        [Route("api/search/countybycase")]
        public string GetCountyByCase(string caseNum)
        {
            var svc = new HHSService();
            return svc.GetCountyByCase(caseNum);
        }
        [HttpGet]
        [Route("api/search/getreferralsbycase")]
        public IEnumerable<ReferralSearchResult> GetReferrals(string caseNum)
        {
            var svc = new HHSService();
            return svc.GetReferralsByCase(caseNum);
        }
        [HttpGet]
        [Route("api/search/getparentsbycase")]
        public IEnumerable<Relationship> GetRelationshipsByCase(string caseNum){
            var svc = new HHSService();
            return svc.GetParentsByCase(caseNum);
        }
        [HttpGet]
        [Route("api/search/getprogramsbycase")]
        public IEnumerable<Program> GetProgramsByCase(string caseNum)
        {
            var svc = new HHSService();
            return svc.GetProgramsByCase(caseNum);
        }
    }
}