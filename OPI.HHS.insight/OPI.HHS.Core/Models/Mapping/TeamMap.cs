using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TeamId, t.Season });

            // Properties
            this.Property(t => t.TeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Season)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Team");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.Season).HasColumnName("Season");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SeasonOpener).HasColumnName("SeasonOpener");
        }
    }
}
