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
    public class SchoolService
    {
        public School Get(int schoolId)
        {
            School rtn = null;
            using (var dbContext = new DAL.DataProDB())
            {
                rtn = dbContext.Schools.AsNoTracking().Include(s => s.Location).AsNoTracking().Where(s => s.Id == schoolId).FirstOrDefault();
            }
            return rtn;
        }
        public IEnumerable<PlayerBio> GetPlayers(int schoolId)
        {
            List<PlayerBio> players = new List<PlayerBio>();
            using (var dbContext = new DAL.DataProDB())
            {
                var p = dbContext.PlayerBios.AsNoTracking().Where(x => x.OrgId == schoolId.ToString()).OrderBy(x => x.Name).ToList();
                        //.Include(s => s.School)
                        //.Where(s => s.OrgId == schoolId.ToString()).OrderBy(x => x.Name).ToList();
                players = p;
            }
            return players;
        }

        public IEnumerable<School> GetSchools()
        {
            List<School> schools = new List<School>();
            using (var dbContext = new DAL.DataProDB())
            {
                var locations = dbContext.Schools.AsNoTracking()
                        .Include(s => s.Location)
                        .Where(s => s.Location != null).ToList();
                foreach (var loc in locations)
                {
                    schools.Add(new School() { Id=loc.Id, Name = loc.Name, Address1 = loc.Address1, Address2 = loc.Address2, City = loc.City, Country = loc.Country, State = loc.State, Zip = loc.Zip, Location = loc.Location });
                }
            }
            return schools;
        }
        public IEnumerable<School> Search(string searchQuery)
        {
            List<School> schools = new List<School>();

            using (var dbContext = new DAL.DataProDB())
            {
                var locations = dbContext.Schools.AsNoTracking()
                        .Include(s => s.Location)
                        .Where(s => s.Location != null 
                        && s.Name.ToLower().Contains(searchQuery)).OrderBy(s => s.Name).ToList();

                foreach (var loc in locations)
                {
                    schools.Add(new School() { Id = loc.Id, Name = loc.Name });
                }
            }
            return schools;
        }
    }
}
