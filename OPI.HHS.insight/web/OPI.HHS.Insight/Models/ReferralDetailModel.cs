using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPI.HHS.Insight.Models
{
    public class ReferralModel
    {
        public int ReferralId { get; set; }
        public string Source { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string DOB { get; set; }
        public string FormattedName
        {
            get
            {
                var rtn = string.Empty;
                if (this.LastName != null && this.LastName.Length > 1) { rtn = this.LastName; }
                if (this.FirstName != null && this.FirstName.Length > 1) { rtn += ", " + this.FirstName; }
                if (this.MiddleName != null && this.MiddleName.Length > 1) { rtn += " " + this.MiddleName; }
                return rtn;
            }
        }
    }
}