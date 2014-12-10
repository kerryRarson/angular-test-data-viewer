using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class HHS_ParentMap : EntityTypeConfiguration<HHS_Parent>
    {
        public HHS_ParentMap()
        {
            // Primary Key
            this.HasKey(t => t.pk_ID);

            // Properties
            this.Property(t => t.pk_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("HHS_Parent");
            this.Property(t => t.pk_ID).HasColumnName("pk_ID");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Suffix).HasColumnName("Suffix");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Race).HasColumnName("Race");
            this.Property(t => t.Ethnicity).HasColumnName("Ethnicity");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.DOBText).HasColumnName("DOBText");
            this.Property(t => t.FileName).HasColumnName("FileName");
        }
    }
}
