using System;

namespace OPI.HHS.Core.Models
{
    public class ProgramImportDetail
    {
        public int CaseNumber { get; set; }
        public int Referral { get; set; }
        public string EligiblityStatus { get; set; }
        public string ProgramCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FileName { get; set; }
    }
}
