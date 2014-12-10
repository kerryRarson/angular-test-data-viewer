using System;

namespace OPI.HHS.Core.Models
{
    public class AddressSearchResult
    {
        public int Case { get; set; }
        public int Referral { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
