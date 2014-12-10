using System;
using System.Collections.Generic;

namespace OPI.HHS.Core.Models
{
    public partial class TeamHistory
    {
        public TeamHistory()
        {
            //this.CurBat_v2 = new List<CurBat_v2>();
            this.PlayerBIOs = new List<curBio_v2>();
        }

        public string Season { get; set; }
        public string TeamId { get; set; }
        public string Team_code { get; set; }
        public string File_code { get; set; }
        public string Franchise_code { get; set; }
        public string BIS_team_code { get; set; }
        public string Name { get; set; }
        public string Name_short { get; set; }
        public string Name_abbrev { get; set; }
        public string Name_display_brief { get; set; }
        public string Name_display_short { get; set; }
        public string Name_display_full { get; set; }
        public string Name_display_long { get; set; }
        public string Sport_code { get; set; }
        public string Sport_code_display { get; set; }
        public string Sport_code_name { get; set; }
        public string League_id { get; set; }
        public string League { get; set; }
        public string Division_id { get; set; }
        public string Division { get; set; }
        public string mlb_org_id { get; set; }
        public string mlb_org_abbrev { get; set; }
        public string mlb_org_brief { get; set; }
        public string mlb_org_short { get; set; }
        public string mlb_org { get; set; }
        public string Venue_id { get; set; }
        public string Venue_name { get; set; }
        //public string Time_zone { get; set; }
        //public string Time_zone_num { get; set; }
        //public string Time_zone_text { get; set; }
        //public string time_zone_generic { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string website_url { get; set; }
        //public string first_year_of_play { get; set; }
        //public string last_year_of_play { get; set; }
        //public string all_star_sw { get; set; }
        //public string active_sw { get; set; }
        public string home_opener { get; set; }
        public string home_opener_time { get; set; }
        //public virtual ICollection<CurBat_v2> CurBat_v2 { get; set; }
        public virtual ICollection<curBio_v2> PlayerBIOs { get; set; }
    }
}
