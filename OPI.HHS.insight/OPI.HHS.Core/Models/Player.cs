using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public int Season { get; set; }
        public int TeamId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string JerseyNumber { get; set; }
        public string PrimaryPosition { get; set; }
        public virtual Team Team { get; set; }
    }
}
