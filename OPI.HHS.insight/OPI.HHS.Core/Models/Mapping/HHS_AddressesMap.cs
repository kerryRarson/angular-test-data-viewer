using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class HHS_AddressesMap : EntityTypeConfiguration<HHS_Addresses>
    {
        public HHS_AddressesMap()
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

            this.Property(t => t.FormattedAddress)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("HHS_Addresses");
            this.Property(t => t.pk_ID).HasColumnName("pk_ID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Line1).HasColumnName("Line1");
            this.Property(t => t.Line2).HasColumnName("Line2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Referral).HasColumnName("Referral");
            this.Property(t => t.CaseNumber).HasColumnName("CaseNumber");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.FormattedAddress).HasColumnName("FormattedAddress");
        }
    }
}
