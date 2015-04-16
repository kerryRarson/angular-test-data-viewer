using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using OPI.HHS.Insight.Models;

namespace OPI.HHS.Insight.Controllers.api
{
    public class GeoCodeController : ApiController
    {
        [HttpPost]
        [Route("api/geocode")]
        public async Task<LatLon> GeoCode(string line1, string line2, string city, string state)
        {
            LatLon rtn = null;
            var geoCodeTask = Task.Run(() => {
                LatLon latLon = null;
                var serviceUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(String.Format("{0}, {1}, {2}, {3}", line1, line2, city, state)));
                var googleRequest = WebRequest.Create(serviceUri);
                var response = googleRequest.GetResponse();
                var xdoc = XDocument.Load(response.GetResponseStream());
                var result = xdoc.Element("GeocodeResponse").Element("result");
                if (result != null)
                {
                    var locationElement = result.Element("geometry").Element("location");
                    latLon = new LatLon
                    {
                        Lat = locationElement.Element("lat").Value,
                        Lon = locationElement.Element("lng").Value,
                        FormattedAddress = result.Element("formatted_address").Value
                    };
                    if (result.Element("partial_match") != null)
                    {
                        if (result.Element("partial_match").Value == "true") { rtn.PartialMatch = true; }
                    }
                }

                return latLon;
            });
            await geoCodeTask;
            rtn = geoCodeTask.Result;
            return rtn;
        }
    }
}
