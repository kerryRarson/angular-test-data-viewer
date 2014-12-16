using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OPI.HHS.Core.Models.Mapping;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core.DAL
{
    public partial class EFContext : DbContext
    {
        static EFContext()
        {
            Database.SetInitializer<EFContext>(null);
        }

        public EFContext()
            : base("Name=EFContext")
        {
            //set the sql command timeout to 2 minutes
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }

        public DbSet<HHS_Addresses> HHS_Addresses { get; set; }
        public DbSet<HHS_Case> HHS_Case { get; set; }
        public DbSet<HHS_Parent> HHS_Parent { get; set; }
        public DbSet<HHS_Programs> HHS_Programs { get; set; }
        public DbSet<HHS_Referrals> HHS_Referrals { get; set; }
        public DbSet<HHS_Relationships> HHS_Relationships { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HHS_AddressesMap());
            modelBuilder.Configurations.Add(new HHS_CaseMap());
            modelBuilder.Configurations.Add(new HHS_ParentMap());
            modelBuilder.Configurations.Add(new HHS_ProgramsMap());
            modelBuilder.Configurations.Add(new HHS_ReferralsMap());
            modelBuilder.Configurations.Add(new HHS_RelationshipsMap());
            modelBuilder.Configurations.Add(new CountyMap());
            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new TeamMap());
        }
    }
}
