using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class FACTORYMap : EntityTypeConfiguration<FACTORY>
    {
        public FACTORYMap()
        {
            // Primary Key
            this.HasKey(t => t.cFactoryCode);

            // Properties
            this.Property(t => t.iFactoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.cFactoryCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.cFactoryDescription)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FACTORY");
            this.Property(t => t.iFactoryID).HasColumnName("iFactoryID");
            this.Property(t => t.cFactoryCode).HasColumnName("cFactoryCode");
            this.Property(t => t.cFactoryDescription).HasColumnName("cFactoryDescription");
        }
    }
}
