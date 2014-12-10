using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PlayerId, t.Season });

            // Properties
            this.Property(t => t.PlayerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Season)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.JerseyNumber)
                .HasMaxLength(2);

            this.Property(t => t.PrimaryPosition)
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("Player");
            this.Property(t => t.PlayerId).HasColumnName("PlayerId");
            this.Property(t => t.Season).HasColumnName("Season");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.JerseyNumber).HasColumnName("JerseyNumber");
            this.Property(t => t.PrimaryPosition).HasColumnName("PrimaryPosition");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(d => new { d.TeamId, d.Season });

        }
    }
}
