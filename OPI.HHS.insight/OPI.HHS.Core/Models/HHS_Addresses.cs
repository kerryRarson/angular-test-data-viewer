using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class HHS_Addresses
    {
        public int pk_ID { get; set; }
        public string Type { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Telephone1 { get; set; }
        public int Referral { get; set; }
        public int CaseNumber { get; set; }
        public string FileName { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public string FormattedAddress { get; set; }
    }
}
