using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class HHS_Parent
    {
        public int pk_ID { get; set; }
        public string Source { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string DOBText { get; set; }
        public string FileName { get; set; }
    }
}
