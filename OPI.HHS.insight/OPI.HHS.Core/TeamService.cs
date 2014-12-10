using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core
{
    public class TeamService
    {
        public TeamHistory Get(int year, int Id)
        {
            TeamHistory rtn = null;
            using (var dbContext = new DAL.DataProDB())
            {
                rtn = dbContext.Teams.AsNoTracking()
                    .Include(t => t.PlayerBIOs).AsNoTracking()
                    .Where(t => t.TeamId == Id.ToString() && t.Season == year.ToString()).FirstOrDefault();
            }
            return rtn;

        }

        public IEnumerable<TeamHistory> GetByLeague(int year, string league)
        {
            List<TeamHistory> teams = new List<TeamHistory>();
            using (var ctx = new DAL.DataProDB())
            {
                teams = ctx.Teams.AsNoTracking()
                    .Where(t => t.Season == year.ToString() && t.Sport_code == league)
                    .OrderBy(t=>t.Name).ToList();
            }
            return teams;
        }
    }
}
