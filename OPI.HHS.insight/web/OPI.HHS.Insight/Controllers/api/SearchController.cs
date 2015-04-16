using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
		public async Task< IEnumerable<string>> GetStates()
		{
            IEnumerable<string> rtn = null;
            rtn = await _svc.GetStatesAsync();
			return rtn;
		}

		[HttpGet]
		[Route("api/search/getcities")]
		public async Task< IEnumerable<string>> GetCities(string st)
		{
            IEnumerable<string> rtn = null;
            rtn = await _svc.GetCitiesAsync(st);
            return rtn.ToList();
		}

		[HttpPost]
		[Route("api/search/bycity")]
		public async Task< IEnumerable<OPI.HHS.Core.Models.AddressSearchResult>> SearchByCity(string st, string city)
		{
			var rtn = await _svc.SearchByCityStateAsync(city, st);
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
		public async Task< IEnumerable<ReferralSearchResult>> SearchByName(string lastName)
		{
            var rtn = await _svc.SearchByNameAsync(lastName);
            return rtn.ToList();
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
		public IEnumerable<Relationship> GetRelationshipsByCase(string caseNum) {
			return _svc.GetParentsByCase(caseNum);
		}

		[HttpGet]
		[Route("api/search/getimportProgramsBycase")]
		public IEnumerable<ProgramImportDetail> GetImportProgramsByCase(int id)
		{
			return _svc.GetImportProgramsByCaseNumber(id);
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