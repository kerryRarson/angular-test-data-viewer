using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core
{
    public class HHSService : IHHSService, IDisposable
    {

        /// <summary>
        /// Gets the programs by case.
        /// </summary>
        /// <param name="caseNum">The case number.</param>
        /// <returns></returns>
        public IEnumerable<Program> GetProgramsByCase(string caseNum) {
            var rtn = new List<Program>();
            int caseNumber = int.Parse(caseNum);
            using (var ctx = new DAL.EFContext())
            {
                rtn = ctx.HHS_Programs
                    .AsNoTracking()
                    .Select(p => new Program { ProgramCode = p.ProgramCode,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        EligiblityStatus = p.EligiblityStatus,
                        CaseNumber = p.CaseNumber,
                        Referral = p.Referral})
                    .Distinct()
                    .Where(p => p.CaseNumber == caseNumber)
                    .OrderByDescending(p => p.StartDate)
                    .ThenBy(p=>p.EndDate)
                    .ToList();
            }
            return rtn;
        }
        /// <summary>
        /// Gets the referrals by case.
        /// </summary>
        /// <param name="caseNum">The case number.</param>
        /// <returns></returns>
        public IEnumerable<ReferralSearchResult> GetReferralsByCase(string caseNum)
        {
            var rtn = new List<ReferralSearchResult>();
            using (var ctx = new DAL.EFContext())
            {
                var sqlQuery = string.Format(@"SELECT DISTINCT r.Id as 'ReferralId'
	                        ,r.Source
	                        ,r.LastName, r.FirstName, r.MiddleName
	                        ,r.Gender
	                        ,r.Race
	                        ,r.Ethnicity
	                        ,r.DOBText as 'DOB'
                        from HHS_Referrals r
                        inner join hhs_case c on r.id = c.referralid
                        where c.casenumber = {0}
                        order by r.LastName, r.FirstName", caseNum);

                rtn = ctx.Database.SqlQuery<ReferralSearchResult>(sqlQuery).ToList();
            }
            return rtn;
        }

        /// <summary>
        /// Gets the parents by case.
        /// </summary>
        /// <param name="caseNum">The case number.</param>
        /// <returns></returns>
        public IEnumerable<Relationship> GetParentsByCase(string caseNum){
            var rtn = new List<Relationship>();
            using(var ctx = new DAL.EFContext()){
                var sqlQuery = string.Format(@"SELECT DISTINCT
                            p.Id
	                        ,p.Source
	                        ,p.LastName, P.FirstName, p.MiddleName
	                        ,p.Gender
	                        ,p.Race
	                        ,p.Ethnicity
	                        ,convert(varchar(10), p.DOB, 127) as 'DOB'
							,case r.relationshipcode when 'PI' then 'Primary' else r.RelationshipCode end as 'RelationshipCode'
                        from HHS_parent p
                        inner join hhs_relationships r on p.id = r.relationshipid
                        where r.casenumber = {0}
                        order by p.LastName, p.FirstName", caseNum);

                rtn = ctx.Database.SqlQuery<Relationship>(sqlQuery).ToList();
            }
            return rtn;
        }
        /// <summary>
        /// Searches by LastName.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <returns>distinct addresses</returns>
        public IEnumerable<ReferralSearchResult> SearchByName(string lastName)
        {
            var rtn = new List<ReferralSearchResult>();
            using (var ctx = new DAL.EFContext())
            {
                var sqlQuery = string.Format(@"SELECT DISTINCT r.Id as 'ReferralId'
	                        ,r.Source
	                        ,r.LastName, r.FirstName, r.MiddleName
	                        ,r.Gender
	                        ,r.Race
	                        ,r.Ethnicity
	                        ,r.DOBText as 'DOB'
                        from HHS_Referrals r
                        where r.LastName like '{0}%'
                        order by r.LastName, r.FirstName", lastName);

                rtn = ctx.Database.SqlQuery<ReferralSearchResult>(sqlQuery).ToList();
            }
            return rtn;
        }
        /// <summary>
        /// Searches by HHS Case number.
        /// </summary>
        /// <param name="caseNumber">The case number.</param>
        /// <returns>distinct addresses</returns>
        public IEnumerable<AddressSearchResult> SearchByCase(int caseNumber)
        {
            var rtn = new List<AddressSearchResult>();
            using (var ctx = new DAL.EFContext())
            {
                rtn = ctx.HHS_Addresses
                     .AsNoTracking()
                     .Select(a => new AddressSearchResult
                     {
                         Line1 = a.Line1,
                         Line2 = a.Line2,
                         City = a.City,
                         State = a.State,
                         Zip = a.PostalCode,
                         Case = a.CaseNumber,
                         Referral = a.Referral,
                         Lat = a.Location.Latitude.ToString(),
                         Lon = a.Location.Longitude.ToString(),
                         FormattedAddress = a.FormattedAddress
                     })
                     .Distinct()
                     .Where(a => a.Case == caseNumber)
                     .OrderBy(a => a.Zip).ThenBy(a => a.Line1).ToList<AddressSearchResult>();
            }
            return rtn;

        }
        /// <summary>
        /// Searches the state of the by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public IEnumerable<AddressSearchResult> SearchByCityState(string city, string state)
        {
            var rtn = new List<AddressSearchResult>();
            using (var ctx = new DAL.EFContext())
            {
                rtn = ctx.HHS_Addresses
                     .AsNoTracking()
                     .Select(a => new AddressSearchResult
                     {
                         Case = a.CaseNumber,
                         Line1 = a.Line1,
                         Line2 = a.Line2,
                         City = a.City,
                         State = a.State,
                         Zip = a.PostalCode,
                         //Case = a.CaseNumber,
                         //Referral = a.Referral,
                         Lat = a.Location.Latitude.ToString(),
                         Lon = a.Location.Longitude.ToString(),
                         FormattedAddress = a.FormattedAddress,
                         Phone = a.Telephone1
                     })
                     .Distinct()
                     .Where(a => a.City.Contains( city) && a.State == state)
                     .OrderBy(a => a.Zip).ThenBy(a => a.FormattedAddress).ToList<AddressSearchResult>();
            }
            return rtn;

         
        }
        /// <summary>
        /// Gets the addresses by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public IEnumerable<HHS_Addresses> GetAddressesByCity(string city, string state)
        {
            List<HHS_Addresses> rtn = new List<HHS_Addresses>();
            using (var ctx = new DAL.EFContext())
            {
                rtn = ctx.HHS_Addresses.Where(a => a.City == city && a.State == state).OrderBy(a => a.PostalCode).ThenBy(a => a.Line1).ToList();
            }

            return rtn;
        }

        public IEnumerable<string> GetStates()
        {
            List<string> rtn = new List<string>();
            using (var ctx = new DAL.EFContext())
            {
                rtn = ctx.HHS_Addresses.Select(a => a.State).Distinct().ToList();
            }
            return rtn;
        }

        public string GetCountyByCase(string caseNumber)
        {
            int iCase = int.Parse(caseNumber);
            string rtn = null;
            using (var ctx = new DAL.EFContext())
            {
                var cases = ctx.HHS_Case
                    .AsNoTracking()
                    .Distinct()
                    .Where(c => c.CaseNumber == iCase)
                    .OrderByDescending( c => c.County)
                    .ToList();
                if (cases.Count > 0) {
                    string countyId = cases.First().County.Value.ToString("00");
                    var county = ctx.Counties
                        .AsNoTracking()
                        .Where(c => c.Co == countyId).FirstOrDefault();

                    rtn = county.Name;
                }
            }
            return rtn == null ? string.Empty : rtn;
        }
        public IEnumerable<LookupModel> SearchCities(string state, string city)
        {
            var found = new List<LookupModel>();
            using (var ctx = new DAL.EFContext())
            {
                found = ctx.HHS_Addresses.AsNoTracking().Where(a => a.State == state && a.City.ToLower().StartsWith(city))
                    .Select(x => new LookupModel() { Key = x.City, Value = x.City }).Distinct().OrderBy(x=>x.Value).ToList();
            }
            return found;
        }

        public IEnumerable<AddressSearchResult> GetAddressesByCase(int caseNum)
        {
            List<AddressSearchResult> rtn = new List<AddressSearchResult>();
            using (var ctx = new DAL.EFContext())
            {
                rtn = ctx.HHS_Addresses
                    .AsNoTracking()
                    .Select(a => new AddressSearchResult
                    {
                        Line1 = a.Line1,
                        Line2 = a.Line2,
                        City = a.City,
                        State = a.State,
                        Zip = a.PostalCode,
                        Case = a.CaseNumber,
                        Referral = a.Referral,
                        Lat = a.Location.Latitude.ToString(),
                        Lon = a.Location.Longitude.ToString(),
                        Phone = a.Telephone1,
                        FormattedAddress = a.FormattedAddress,
                        Type = a.Type
                    })
                     .Distinct()
                     .Where(a => a.Case == caseNum)
                     .OrderBy(a => a.Zip).ThenBy(a => a.FormattedAddress).ToList<AddressSearchResult>();
            }
            // != null ? String.Format("{0:(###) ###-####}", a.Telephone1) : string.Empty,
            //format the phone
            foreach (var a in rtn)
            {
                if (a.Phone != null && a.Phone.Length > 1)
                {
                    a.Phone = string.Format("{0:(###) ###-####}", long.Parse(a.Phone));
                }
            }
            return rtn;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
