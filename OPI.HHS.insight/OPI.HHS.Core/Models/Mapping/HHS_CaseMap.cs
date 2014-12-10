using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class HHS_CaseMap : EntityTypeConfiguration<HHS_Case>
    {
        public HHS_CaseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.pk_ID, t.CaseNumber, t.ReferralId });

            // Properties
            this.Property(t => t.pk_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CaseNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ReferralId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("HHS_Case");
            this.Property(t => t.pk_ID).HasColumnName("pk_ID");
            this.Property(t => t.CaseNumber).HasColumnName("CaseNumber");
            this.Property(t => t.ReferralId).HasColumnName("ReferralId");
            this.Property(t => t.County).HasColumnName("County");
            this.Property(t => t.FileName).HasColumnName("FileName");
        }
    }
}
