﻿using System;

namespace OPI.HHS.Core.Models
{
    public class Relationship
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public string RelationshipCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string DOB { get; set; }
        public string FormattedName
        {
            get
            {
                var rtn = string.Empty;
                if (LastName != null) rtn += LastName;
                if (FirstName != null) rtn += ", " + FirstName;
                if (MiddleName != null)
                {
                    if (MiddleName.Length > 0) rtn += " " + MiddleName;
                }
                return rtn.Trim();
            }
        }
    }
}
