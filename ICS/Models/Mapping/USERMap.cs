using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class USERMap : EntityTypeConfiguration<USER>
    {
        public USERMap()
        {
            // Primary Key
            this.HasKey(t => t.cUserName);

            // Properties
            this.Property(t => t.iAutoIndex)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.cUserName)
                .IsRequired()
                .HasMaxLength(56);

            this.Property(t => t.cComputer)
                .HasMaxLength(50);

            this.Property(t => t.cPassword)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("USER");
            this.Property(t => t.iAutoIndex).HasColumnName("iAutoIndex");
            this.Property(t => t.cUserName).HasColumnName("cUserName");
            this.Property(t => t.iFactoryID).HasColumnName("iFactoryID");
            this.Property(t => t.bActive).HasColumnName("bActive");
            this.Property(t => t.bAdmin).HasColumnName("bAdmin");
            this.Property(t => t.cComputer).HasColumnName("cComputer");
            this.Property(t => t.cPassword).HasColumnName("cPassword");
        }
    }
}
