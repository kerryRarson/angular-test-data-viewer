using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class HHS_Programs
    {
        public int pk_ID { get; set; }
        public string EligiblityStatus { get; set; }
        public string ProgramCode { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int Referral { get; set; }
        public int CaseNumber { get; set; }
        public string StartDateText { get; set; }
        public string EndDateText { get; set; }
        public string FileName { get; set; }
    }
}
