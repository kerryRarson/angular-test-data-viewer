using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class HHS_Case
    {
        public int pk_ID { get; set; }
        public int CaseNumber { get; set; }
        public int ReferralId { get; set; }
        public Nullable<int> County { get; set; }
        public string FileName { get; set; }
    }
}
