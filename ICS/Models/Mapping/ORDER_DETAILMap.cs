using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class ORDER_DETAILMap : EntityTypeConfiguration<ORDER_DETAIL>
    {
        public ORDER_DETAILMap()
        {
            // Primary Key
            this.HasKey(t => t.idPOLine);

            // Properties
            this.Property(t => t.cArticleDescription2)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ORDER_DETAIL");
            this.Property(t => t.idPOLine).HasColumnName("idPOLine");
            this.Property(t => t.iPOID).HasColumnName("iPOID");
            this.Property(t => t.iArticleID).HasColumnName("iArticleID");
            this.Property(t => t.cArticleDescription2).HasColumnName("cArticleDescription2");
            this.Property(t => t.dOrderQuantity).HasColumnName("dOrderQuantity");
            this.Property(t => t.dRecievedQuantity).HasColumnName("dRecievedQuantity");
            this.Property(t => t.dUnitPrice).HasColumnName("dUnitPrice");
            this.Property(t => t.dValue).HasColumnName("dValue");
        }
    }
}
