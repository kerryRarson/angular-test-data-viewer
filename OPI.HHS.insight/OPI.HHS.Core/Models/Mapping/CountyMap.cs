using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OPI.HHS.Core.Models.Mapping
{
    public class CountyMap : EntityTypeConfiguration<County>
    {
        public CountyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Co });

            // Properties
            this.Property(t => t.Co)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

           

            // Table & Column Mappings
            this.ToTable("County");
            
        }
    }
}
