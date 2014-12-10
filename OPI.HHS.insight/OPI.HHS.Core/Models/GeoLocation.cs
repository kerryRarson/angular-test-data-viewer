using System;
using System.Data.Entity.Spatial;
namespace OPI.HHS.Core.Models
{
    public class GeoLocation
    {
        public GeoLocation() { }

        public Int64 TeamId { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DbGeography Location { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public string FormattedAddress { get; set; }
        public virtual School School { get; set; }

    }
}
