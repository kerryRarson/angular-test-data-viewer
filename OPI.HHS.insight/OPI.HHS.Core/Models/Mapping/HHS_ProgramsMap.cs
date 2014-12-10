using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class HHS_ProgramsMap : EntityTypeConfiguration<HHS_Programs>
    {
        public HHS_ProgramsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.pk_ID, t.Referral, t.CaseNumber });

            // Properties
            this.Property(t => t.pk_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Referral)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CaseNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("HHS_Programs");
            this.Property(t => t.pk_ID).HasColumnName("pk_ID");
            this.Property(t => t.EligiblityStatus).HasColumnName("EligiblityStatus");
            this.Property(t => t.ProgramCode).HasColumnName("ProgramCode");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Referral).HasColumnName("Referral");
            this.Property(t => t.CaseNumber).HasColumnName("CaseNumber");
            this.Property(t => t.StartDateText).HasColumnName("StartDateText");
            this.Property(t => t.EndDateText).HasColumnName("EndDateText");
            this.Property(t => t.FileName).HasColumnName("FileName");
        }
    }
}
