using System;

namespace OPI.HHS.Insight.Models
{
    public class LatLon
    {
        public string Lat { get; set; }
        public string Lon { get; set; }
        public bool PartialMatch { get; set; }
        public string FormattedAddress { get; set; }
    }
}