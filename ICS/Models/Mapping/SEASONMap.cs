using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class SEASONMap : EntityTypeConfiguration<SEASON>
    {
        public SEASONMap()
        {
            // Primary Key
            this.HasKey(t => t.cSeasonCode);

            // Properties
            this.Property(t => t.iSeasonID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.cSeasonCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.cSeasonDescription1)
                .HasMaxLength(50);

            this.Property(t => t.cSeasonDescription2)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SEASON");
            this.Property(t => t.iSeasonID).HasColumnName("iSeasonID");
            this.Property(t => t.cSeasonCode).HasColumnName("cSeasonCode");
            this.Property(t => t.cSeasonDescription1).HasColumnName("cSeasonDescription1");
            this.Property(t => t.cSeasonDescription2).HasColumnName("cSeasonDescription2");
        }
    }
}
