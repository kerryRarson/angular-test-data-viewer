using System;

namespace OPI.HHS.Core.Models
{
    public class PlayerBio
    {
        public PlayerBio() { }

        public string PlayerId { get; set; }
        public string Year { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public string First { get; set; }
        public string TeamId { get; set; }
        public string TeamAbbreviation { get; set; }
        public string OrgId { get; set; }
        public string OrgAbbreviation { get; set; }
        public string Matrilineal { get; set; }
        public string PositionCode { get; set; }
        public string UniformNumber { get; set; }
        public string EBISPlayerId { get; set; }
        public string Bats { get; set; }
        public string Throws { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string HomeTown { get; set; }
        public string HowObtained { get; set; }
        public string College { get; set; }
        public string DateSigned { get; set; }
        public string Street { get; set; }
        public string CSZ { get; set; }
        //public virtual School School { get; set; }
    }
}
