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

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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