using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class GRN_HEADERMap : EntityTypeConfiguration<GRN_HEADER>
    {
        public GRN_HEADERMap()
        {
            // Primary Key
            this.HasKey(t => t.iGRNID);

            // Properties
            this.Property(t => t.cReference)
                .HasMaxLength(50);

            this.Property(t => t.cRemarks)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GRN_HEADER");
            this.Property(t => t.iGRNID).HasColumnName("iGRNID");
            this.Property(t => t.dDate).HasColumnName("dDate");
            this.Property(t => t.cReference).HasColumnName("cReference");
            this.Property(t => t.iPOID).HasColumnName("iPOID");
            this.Property(t => t.iFactoryID).HasColumnName("iFactoryID");
            this.Property(t => t.cRemarks).HasColumnName("cRemarks");
            this.Property(t => t.bReceived).HasColumnName("bReceived");
            this.Property(t => t.dValue).HasColumnName("dValue");
            this.Property(t => t.bUpdated).HasColumnName("bUpdated");
            this.Property(t => t.bDeleted).HasColumnName("bDeleted");
        }
    }
}
