using System;

namespace OPI.HHS.Core.Models
{
    public class Program
    {
        
        
        public string ProgramCode { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int Referral { get; set; }
        public int CaseNumber { get; set; }
        public string StartDateText { get {
            var rtn = string.Empty;
            if (this.StartDate.HasValue)
            {
                rtn = this.StartDate.Value.ToShortDateString();
            }
            return rtn;
            }
        }
        public string EndDateText
        {
            get
            {
                var rtn = string.Empty;
                if (this.EndDate.HasValue) { rtn = this.EndDate.Value.ToShortDateString(); }
                return rtn;
            }
        }
        public string EligiblityStatus { get; set; }
        public string EligiblityStatusText
        {
            get
            {
                var rtn = string.Empty;
                if (this.EligiblityStatus != null) {
                    switch (this.EligiblityStatus.ToUpper())
                    {
                        case "O":
                            rtn = "Open";
                            break;
                        case "C":
                            rtn = "Closed";
                            break;
                        default:
                            rtn = this.EligiblityStatus;
                            break;
                    }
                }
                return rtn;
            }
        }
    }
}
