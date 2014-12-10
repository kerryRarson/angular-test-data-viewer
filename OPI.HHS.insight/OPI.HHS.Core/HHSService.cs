﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core
{
    public class HHSService
    {
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
                         Lon = a.Location.Longitude.ToString()
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
                         Line1 = a.Line1,
                         Line2 = a.Line2,
                         City = a.City,
                         State = a.State,
                         Zip = a.PostalCode,
                         Case = a.CaseNumber,
                         Referral = a.Referral,
                         Lat = a.Location.Latitude.ToString(),
                         Lon = a.Location.Longitude.ToString()
                     })
                     .Distinct()
                     .Where(a => a.City == city && a.State == state)
                     .OrderBy(a => a.Zip).ThenBy(a => a.Line1).ToList<AddressSearchResult>();
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
    }
}
