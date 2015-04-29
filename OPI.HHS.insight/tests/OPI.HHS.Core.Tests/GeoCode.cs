using System;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OPI.HHS.Core.DAL;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core.Tests
{
    [TestClass]
    public class GeoCode
    {
        protected readonly string _startCity = "lame deer".ToUpper();
        /// <summary>
        /// Creates the point.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        private DbGeography CreatePoint(double latitude, double longitude)
        {
            var text = string.Format(System.Globalization.CultureInfo.InvariantCulture.NumberFormat,
                                     "POINT({0} {1})", longitude, latitude);
            // 4326 is most common coordinate system used by GPS/Maps
            return DbGeography.PointFromText(text, 4326);
        }
        [TestMethod]
        public void GeoCodeAddresses()
        {
            //Assert.Inconclusive("Remove this to GeoCode.");
            bool foundStart = true;
            bool overLimit = false;

            //var svc = new Demo.Layers.Core.HHSService();
            using (var db = new EFContext())
            {
                var addrs = db.HHS_Addresses.Where(a => a.FormattedAddress == null).OrderBy(a=>a.City).ToList();
                foreach (var a in addrs)
                {
                    //if (!foundStart && a.City.ToUpper().Equals(_startCity)) { foundStart = true; }
                    if (foundStart)
                    {
                        //only geocode if there isn't one
                        var loc = db.HHS_Addresses.Where(x => x.Location != null
                            && x.Line1 == a.Line1
                            && x.Line1 == a.Line1
                            && x.City == a.City && x.State == a.State
                            && x.PostalCode == a.PostalCode).ToList();
                        if (loc.Count == 0)
                        {
                            //geocode the address
                            var serviceUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(String.Format("{0}, {1}, {2}, {3}", a.Line1, a.Line2, a.City, a.State)));
                            var request = WebRequest.Create(serviceUri);
                            try
                            {
                                var response = request.GetResponse();

                                var xdoc = XDocument.Load(response.GetResponseStream());

                                var result = xdoc.Element("GeocodeResponse").Element("result");
                                if (result != null)
                                {
                                    var locationElement = result.Element("geometry").Element("location");
                                    var latitude = locationElement.Element("lat").Value;var longitude = locationElement.Element("lng").Value;
                                    var formattedAddr = result.Element("formatted_address").Value;
                                    System.Diagnostics.Debug.WriteLine(formattedAddr);
                                    a.FormattedAddress = formattedAddr;
                                    a.Location = CreatePoint(Convert.ToDouble(latitude), Convert.ToDouble(longitude));
                                    db.SaveChanges();
                                }
                                else
                                {
                                    if (xdoc.Element("GeocodeResponse").Element("status").Value == "OVER_QUERY_LIMIT") { overLimit = true; Assert.Fail("Over quota limit " + DateTime.Now.ToString()); }
                                    System.Diagnostics.Debug.WriteLine(string.Format("NO RESULT FOR - {0}", a.pk_ID));
                                    a.FormattedAddress = "NO RESULT";
                                    db.SaveChanges();
                                }
                            }
                            catch (Exception err)
                            {
                                System.Diagnostics.Debug.WriteLine(err.ToString());
                                //bubble it back to the test harness
                                if (overLimit) Assert.Fail(err.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}
