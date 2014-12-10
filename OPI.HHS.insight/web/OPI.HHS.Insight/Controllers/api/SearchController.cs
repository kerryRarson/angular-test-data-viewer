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

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}