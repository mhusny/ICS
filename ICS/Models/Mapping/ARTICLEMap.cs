using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class ARTICLEMap : EntityTypeConfiguration<ARTICLE>
    {
        public ARTICLEMap()
        {
            // Primary Key
            this.HasKey(t => t.cArticleCode);

            // Properties
            this.Property(t => t.iArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.cArticleCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.cArticleDescription1)
                .HasMaxLength(50);

            this.Property(t => t.cArticleDescription2)
                .HasMaxLength(50);

            this.Property(t => t.cStyleDescription)
                .HasMaxLength(50);

            this.Property(t => t.cUOM)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ARTICLE");
            this.Property(t => t.iArticleID).HasColumnName("iArticleID");
            this.Property(t => t.cArticleCode).HasColumnName("cArticleCode");
            this.Property(t => t.cArticleDescription1).HasColumnName("cArticleDescription1");
            this.Property(t => t.cArticleDescription2).HasColumnName("cArticleDescription2");
            this.Property(t => t.iSeasonID).HasColumnName("iSeasonID");
            this.Property(t => t.cStyleDescription).HasColumnName("cStyleDescription");
            this.Property(t => t.bActive).HasColumnName("bActive");
            this.Property(t => t.cUOM).HasColumnName("cUOM");
            this.Property(t => t.dQtyInStock).HasColumnName("dQtyInStock");
        }
    }
}
