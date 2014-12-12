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
        public void GetStates()
        {
            var ctx = new HHSService();
            var states = ctx.GetStates();
            Assert.IsNotNull(states);
            Assert.IsTrue(states.Count() > 0);

        }

        [TestMethod]
        public void GetAddrsByStateCity()
        {
            var ctx = new HHSService();
            var searchState = "MT";
            var searchCity = "Whitefish";
            var results = ctx.GetAddressesByCity(searchCity, searchState);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);

        }

        [TestMethod]
        public void SearchByName()
        {
            var ctx = new HHSService();
            var results = ctx.SearchByName("lars");
            Assert.IsNotNull(results);
            Console.WriteLine("found {0} HHS Referrals", results.Count());
        }
        [TestMethod]
        public void SearchByStateCity()
        {
            var ctx = new HHSService();
            var searchState = "MT";
            var searchCity = "Whitefish";
            var results = ctx.SearchByCityState(searchCity, searchState);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
            Console.WriteLine("{0} addresses returned", results.Count());
        }

        [TestMethod]
        public void SearchByCaseNumber()
        {
            var ctx = new HHSService();
            int searchCase = 612207;
            var results = ctx.SearchByCase(searchCase);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
        }
    }
}
