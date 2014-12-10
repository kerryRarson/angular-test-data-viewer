using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class HHS_Relationships
    {
        public int pk_ID { get; set; }
        public string RelationshipId { get; set; }
        public string RelationshipCode { get; set; }
        public string Referral { get; set; }
        public string CaseNumber { get; set; }
        public string FileName { get; set; }
    }
}
