using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OPI.HHS.Core.DAL;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core.Tests
{
    [TestClass]
    public class Search
    {
        [TestMethod]
        public void GetProgramImportRowsByReferral()
        {
            using (var svc = new HHSService())
            {
                var actual = svc.GetImportProgramsByReferral(1762453);
                Assert.IsNotNull(actual);
                Console.WriteLine("{0} rows returned.", actual.Count());
            }
        }
        [TestMethod]
        public void GetProgramImportRowsByCase()
        {
            using (var svc = new HHSService())
            {
                var actual = svc.GetImportProgramsByCaseNumber(422567);
                Assert.IsNotNull(actual);
                Console.WriteLine("{0} rows returned.", actual.Count());
            }
        }
        [TestMethod]
        public void GetStates()
        {
            using (var ctx = new HHSService())
            {
                var states = ctx.GetStates();
                Assert.IsNotNull(states);
                Assert.IsTrue(states.Count() > 0); 
            }
            

        }
        [TestMethod]
        public void GetCities()
        {
            using (var svc = new HHSService())
            {
                var cities = svc.GetCities("IL");
                Assert.IsNotNull(cities);
                Assert.IsTrue(cities.Count() > 0);
            }
        }
        [TestMethod]
        public void GetAddrsByStateCity()
        {
            using (var ctx = new HHSService())
            {
                var searchState = "MT";
                var searchCity = "Whitefish";
                var results = ctx.GetAddressesByCity(searchCity, searchState);
                Assert.IsNotNull(results);
                Assert.IsTrue(results.Count() > 0);
            }

        }
        [TestMethod]
        public void GetAddressesByCase()
        {
            using (var ctx = new HHSService())
            {
                var actual = ctx.GetAddressesByCase(422567);
                Assert.IsNotNull(actual);
                Assert.IsTrue(actual.Count() > 0);
            }
        }
        [TestMethod]
        public void SearchByName()
        {
            using (var ctx = new HHSService())
            {
                var results = ctx.SearchByName("lars");
                Assert.IsNotNull(results);
                Console.WriteLine("found {0} HHS Referrals", results.Count());

                //test the async method
                results = ctx.SearchByNameAsync("lars");
                Assert.IsNotNull(results);
                Console.WriteLine("found {0} HHS Referrals from async search", results.Count());
            }
        }
        [TestMethod]
        public void SearchByStateCity()
        {
            using (var ctx = new HHSService())
            {
                var searchState = "MT";
                var searchCity = "Whitefish";
                var results = ctx.SearchByCityState(searchCity, searchState);
                Assert.IsNotNull(results);
                Assert.IsTrue(results.Count() > 0);
                Console.WriteLine("{0} addresses returned", results.Count());
            }
        }

        [TestMethod]
        public void SearchByCaseNumber()
        {
            using (var ctx = new HHSService())
            {
                int searchCase = 612207;
                var results = ctx.SearchByCase(searchCase);
                Assert.IsNotNull(results);
                Assert.IsTrue(results.Count() > 0);
            }
        }

        [TestMethod]
        public void GetCountyByCase()
        {
            using (var ctx = new HHSService())
            {
                var actual = ctx.GetCountyByCase("440061");
                Assert.IsNotNull(actual);
                Console.WriteLine("returned - {0}", actual);
            }
        }

        [TestMethod]
        public void GetReferral()
        {
            using (var svc = new HHSService())
            {
                var actual = svc.GetReferral(1762453);
                Assert.IsNotNull(actual);
                Console.WriteLine("returned {0}, {1}", actual.LastName, actual.FirstName);
            }
        }
        [TestMethod]
        public void GetProgramsByReferral()
        {
            using (var svc = new HHSService())
            {
                var actual = svc.GetProgramsByReferral(1784783);
                Assert.IsNotNull(actual);
                Console.WriteLine("Referral 1784783 returned {0} rows", actual.Count());
            }
        }
        [TestMethod]
        public void GetProgramsByCase()
        {
            using (var svc = new HHSService())
            {
                var actual = svc.GetProgramsByCase("601615");
                Assert.IsNotNull(actual);
                Console.WriteLine("Case 601615 returned {0} rows", actual.Count());
            }
        }
    }
}
