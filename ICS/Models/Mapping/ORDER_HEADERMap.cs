using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class ORDER_HEADERMap : EntityTypeConfiguration<ORDER_HEADER>
    {
        public ORDER_HEADERMap()
        {
            // Primary Key
            this.HasKey(t => t.iPOID);

            // Properties
            this.Property(t => t.cReference)
                .HasMaxLength(50);

            this.Property(t => t.cSupplierCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.cRemarks)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ORDER_HEADER");
            this.Property(t => t.iPOID).HasColumnName("iPOID");
            this.Property(t => t.dDate).HasColumnName("dDate");
            this.Property(t => t.cReference).HasColumnName("cReference");
            this.Property(t => t.iFactoryID).HasColumnName("iFactoryID");
            this.Property(t => t.iSupplierID).HasColumnName("iSupplierID");
            this.Property(t => t.cSupplierCode).HasColumnName("cSupplierCode");
            this.Property(t => t.cRemarks).HasColumnName("cRemarks");
            this.Property(t => t.bRecieved).HasColumnName("bRecieved");
            this.Property(t => t.bDeleted).HasColumnName("bDeleted");
        }
    }
}
