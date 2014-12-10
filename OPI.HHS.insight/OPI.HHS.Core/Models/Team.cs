using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
        }

        public int TeamId { get; set; }
        public int Season { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> SeasonOpener { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
