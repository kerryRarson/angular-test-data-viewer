using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class HHS_RelationshipsMap : EntityTypeConfiguration<HHS_Relationships>
    {
        public HHS_RelationshipsMap()
        {
            // Primary Key
            this.HasKey(t => t.pk_ID);

            // Properties
            this.Property(t => t.pk_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("HHS_Relationships");
            this.Property(t => t.pk_ID).HasColumnName("pk_ID");
            this.Property(t => t.RelationshipId).HasColumnName("RelationshipId");
            this.Property(t => t.RelationshipCode).HasColumnName("RelationshipCode");
            this.Property(t => t.Referral).HasColumnName("Referral");
            this.Property(t => t.CaseNumber).HasColumnName("CaseNumber");
            this.Property(t => t.FileName).HasColumnName("FileName");
        }
    }
}
