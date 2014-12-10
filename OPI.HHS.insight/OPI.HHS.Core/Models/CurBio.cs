using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class curBio_v2
    {
        public string Id { get; set; }
        public string Season { get; set; }
        public string Player { get; set; }
        public string Last { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Use { get; set; }
        public string Matrilineal { get; set; }
        public string TeamId { get; set; }
        public string OrganizationId { get; set; }
        public string PrimaryPosition { get; set; }
        public string JerseyNumber { get; set; }
        public string EBIS_Id { get; set; }
        public string Bats { get; set; }
        public string Throws { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string HowObtained { get; set; }
        public string College { get; set; }
        public string DateSigned { get; set; }
        public virtual TeamHistory TeamHistory { get; set; }
    }
}
