using OPI.HHS.Core.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace OPI.HHS.Core.DAL
{
    public class DataProDB : DbContext
    {
        //change EF's default db to datapro & turn off migrations
        public DataProDB()
            : base("DataPro")
        {
            //Disable initializer
            Database.SetInitializer<DataProDB>(null);
        }

        //public DbSet<Client> Clients { get; set; }
        //public DbSet<PlayerDetail> PlayerDetails { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<GeoLocation> Locations { get; set; }
        public DbSet<PlayerBio> PlayerBios { get; set; }
        public DbSet<TeamHistory> Teams { get; set; }
        public DbSet<curBio_v2> CurBios { get; set; }

        #region Mappings
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Client>().ToTable("Clients", "app");
            //modelBuilder.Entity<Client>().HasKey(t => t.Id);

            //modelBuilder.Entity<PlayerDetail>().ToTable("PlayerDetails", "info");
            //modelBuilder.Entity<PlayerDetail>().HasKey(t => t.PlayerId);

            modelBuilder.Entity<School>().ToTable("GBL_SCHTEAM", "global");
            modelBuilder.Entity<School>().HasKey(t => t.Id);
            modelBuilder.Entity<School>().Property(t => t.Id).HasColumnName("schteam_id");
            modelBuilder.Entity<School>().Property(t => t.SchoolType).HasColumnName("schteamtype_lk");
            modelBuilder.Entity<School>().Property(t => t.Name).HasColumnName("schTeamName");
            modelBuilder.Entity<School>().Property(t => t.State).HasColumnName("state_lk");
            modelBuilder.Entity<School>().Property(t => t.Zip).HasColumnName("zipcode");
            modelBuilder.Entity<School>().Property(t => t.Country).HasColumnName("country_lk");

            modelBuilder.Entity<GeoLocation>().ToTable("GeoLocation", "global");
            //for navigation mapping
            modelBuilder.Entity<GeoLocation>().HasKey(t => t.TeamId);
            //for identity 
            //modelBuilder.Entity<GeoLocation>().HasKey(t => t.Id);
            //modelBuilder.Entity<GeoLocation>().Property(l=> l.Lat).has .HasPrecision(12, 7);
            //modelBuilder.Entity<GeoLocation>().Property(l => l.Lon).HasPrecision(12, 7);

            // Relationships
            modelBuilder.Entity<GeoLocation>()
                .HasRequired<School>(x => x.School)
                .WithOptional(x => x.Location);
            //modelBuilder.Entity<GeoLocation>()
            //    .HasRequired<School>(s => s.School)
            //    .WithMany().HasForeignKey(l => l.TeamId);

            #region Player BIO
            modelBuilder.Entity<PlayerBio>().ToTable("curBio_Import", "dbo");
            modelBuilder.Entity<PlayerBio>().HasKey(t => t.PlayerId);
            modelBuilder.Entity<PlayerBio>().Property(t => t.PlayerId).HasColumnName("Player_ID");
            modelBuilder.Entity<PlayerBio>().Property(t => t.TeamId).HasColumnName("Team_ID");
            modelBuilder.Entity<PlayerBio>().Property(t => t.TeamAbbreviation).HasColumnName("TEAM_ABBREV");
            modelBuilder.Entity<PlayerBio>().Property(t => t.OrgId).HasColumnName("Org_ID");
            modelBuilder.Entity<PlayerBio>().Property(t => t.OrgAbbreviation).HasColumnName("ORG_ABBREV");
            modelBuilder.Entity<PlayerBio>().Property(t => t.PositionCode).HasColumnName("Pos");
            modelBuilder.Entity<PlayerBio>().Property(t => t.UniformNumber).HasColumnName("Uniform_NO");
            modelBuilder.Entity<PlayerBio>().Property(t => t.EBISPlayerId).HasColumnName("ebis_player_id");
            modelBuilder.Entity<PlayerBio>().Property(t => t.BirthDate).HasColumnName("birth_date");
            modelBuilder.Entity<PlayerBio>().Property(t => t.BirthPlace).HasColumnName("birth_place");
            modelBuilder.Entity<PlayerBio>().Property(t => t.HowObtained).HasColumnName("how_obtained");
            modelBuilder.Entity<PlayerBio>().Property(t => t.DateSigned).HasColumnName("date_signed");
            modelBuilder.Entity<PlayerBio>().Property(t => t.CSZ).HasColumnName("city_state_zip");
            //modelBuilder.Entity<PlayerBio>().HasRequired<School>(x => x.School).WithMany().HasForeignKey(l => l.OrgId);
            #endregion


            #region CurBio
            modelBuilder.Entity<curBio_v2>().ToTable("curbio_v2", "temp");
            // Primary Key
            modelBuilder.Entity<curBio_v2>().HasKey(t => new { t.Id, t.Season });
            modelBuilder.Entity<curBio_v2>().Property(t => t.Id).HasColumnName("player_id");
            modelBuilder.Entity<curBio_v2>().Property(t => t.Last).HasColumnName("name_last");
            modelBuilder.Entity<curBio_v2>().Property(t => t.First).HasColumnName("name_first");
            modelBuilder.Entity<curBio_v2>().Property(t => t.Middle).HasColumnName("name_middle");
            modelBuilder.Entity<curBio_v2>().Property(t => t.Use).HasColumnName("name_use");
            modelBuilder.Entity<curBio_v2>().Property(t => t.Matrilineal).HasColumnName("name_matrilineal");
            modelBuilder.Entity<curBio_v2>().Property(t => t.TeamId).HasColumnName("team_id");
            modelBuilder.Entity<curBio_v2>().Property(t => t.OrganizationId).HasColumnName("organization_id");
            modelBuilder.Entity<curBio_v2>().Property(t => t.PrimaryPosition).HasColumnName("primary_position");
            modelBuilder.Entity<curBio_v2>().Property(t => t.JerseyNumber).HasColumnName("jersey_number");
            modelBuilder.Entity<curBio_v2>().Property(t => t.EBIS_Id).HasColumnName("bis_id");
            modelBuilder.Entity<curBio_v2>().Property(t => t.BirthDate).HasColumnName("birth_date");
            modelBuilder.Entity<curBio_v2>().Property(t => t.BirthPlace).HasColumnName("birth_place");
            modelBuilder.Entity<curBio_v2>().Property(t => t.HowObtained).HasColumnName("how_obtained");
            modelBuilder.Entity<curBio_v2>().Property(t => t.DateSigned).HasColumnName("date_signed");
            // Relationships
            modelBuilder.Entity<curBio_v2>().HasRequired(t => t.TeamHistory)
                .WithMany(t => t.PlayerBIOs)
                .HasForeignKey(d => new { d.TeamId, d.Season });



            #endregion

            #region TeamHistory
            modelBuilder.Entity<TeamHistory>().ToTable("TeamHistory", "temp");
            //Primary Key
            modelBuilder.Entity<TeamHistory>().HasKey(t => new { t.TeamId, t.Season });
            modelBuilder.Entity<TeamHistory>().Property(t => t.TeamId).HasColumnName("team_id");
            
            #endregion
        }
        #endregion
    }
}
