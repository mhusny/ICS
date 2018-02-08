using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class SUPPLIERMap : EntityTypeConfiguration<SUPPLIER>
    {
        public SUPPLIERMap()
        {
            // Primary Key
            this.HasKey(t => t.cSupplierCode);

            // Properties
            this.Property(t => t.iSupplierID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.cSupplierCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.cSupplierName)
                .HasMaxLength(50);

            this.Property(t => t.cAddress1)
                .HasMaxLength(50);

            this.Property(t => t.cAddress2)
                .HasMaxLength(50);

            this.Property(t => t.cAddress3)
                .HasMaxLength(50);

            this.Property(t => t.cAddress4)
                .HasMaxLength(50);

            this.Property(t => t.cAddress5)
                .HasMaxLength(50);

            this.Property(t => t.cContactName)
                .HasMaxLength(50);

            this.Property(t => t.cContactDetails)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SUPPLIER");
            this.Property(t => t.iSupplierID).HasColumnName("iSupplierID");
            this.Property(t => t.cSupplierCode).HasColumnName("cSupplierCode");
            this.Property(t => t.cSupplierName).HasColumnName("cSupplierName");
            this.Property(t => t.cAddress1).HasColumnName("cAddress1");
            this.Property(t => t.cAddress2).HasColumnName("cAddress2");
            this.Property(t => t.cAddress3).HasColumnName("cAddress3");
            this.Property(t => t.cAddress4).HasColumnName("cAddress4");
            this.Property(t => t.cAddress5).HasColumnName("cAddress5");
            this.Property(t => t.cContactName).HasColumnName("cContactName");
            this.Property(t => t.cContactDetails).HasColumnName("cContactDetails");
        }
    }
}
