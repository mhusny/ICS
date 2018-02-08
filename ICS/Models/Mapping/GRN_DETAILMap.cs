using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Models.Mapping
{
    public class GRN_DETAILMap : EntityTypeConfiguration<GRN_DETAIL>
    {
        public GRN_DETAILMap()
        {
            // Primary Key
            this.HasKey(t => t.idGRNLinees);

            // Properties
            this.Property(t => t.cArticleDescription2)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("GRN_DETAIL");
            this.Property(t => t.idGRNLinees).HasColumnName("idGRNLinees");
            this.Property(t => t.iGRNID).HasColumnName("iGRNID");
            this.Property(t => t.iPOID).HasColumnName("iPOID");
            this.Property(t => t.idPOLine).HasColumnName("idPOLine");
            this.Property(t => t.iArticleID).HasColumnName("iArticleID");
            this.Property(t => t.cArticleDescription2).HasColumnName("cArticleDescription2");
            this.Property(t => t.dQuantityOrder).HasColumnName("dQuantityOrder");
            this.Property(t => t.bQuantityReceived).HasColumnName("bQuantityReceived");
            this.Property(t => t.dQuantity).HasColumnName("dQuantity");
            this.Property(t => t.dUnitPrice).HasColumnName("dUnitPrice");
            this.Property(t => t.dNetValue).HasColumnName("dNetValue");
            this.Property(t => t.dTaxRate).HasColumnName("dTaxRate");
            this.Property(t => t.dTaxValue).HasColumnName("dTaxValue");
            this.Property(t => t.dGrossValue).HasColumnName("dGrossValue");
            this.Property(t => t.dValue).HasColumnName("dValue");
        }
    }
}
