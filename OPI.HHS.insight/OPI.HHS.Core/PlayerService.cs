using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core
{
    public class PlayerService
    {
        public IEnumerable<curBio_v2> GetByTeam(int teamId, int year)
        {
            List<curBio_v2> rtn = new List<curBio_v2>();
            using (var ctx = new DAL.DataProDB())
            {
                rtn = ctx.CurBios.Where(b => b.TeamId == teamId.ToString() && b.Season == year.ToString()).ToList();
            }
            return rtn;
        }
        public curBio_v2 Get(int playerId, int year)
        {
            using (var ctx = new DAL.DataProDB())
            {
                return ctx.CurBios.AsNoTracking()
                    .Where(b => b.Id == playerId.ToString() && b.Season == year.ToString())
                    .FirstOrDefault();
            }
        }
    }
}
