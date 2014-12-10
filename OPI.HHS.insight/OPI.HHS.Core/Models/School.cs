using System;

namespace OPI.HHS.Core.Models
{
    public class School
    {
        public School() { }

        public Int64 Id { get; set; }
        public string SchoolType { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public virtual GeoLocation Location { get; set; }
    }
}
