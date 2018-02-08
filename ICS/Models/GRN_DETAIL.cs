using System;
using System.Collections.Generic;

namespace ICS.Models
{
    public partial class GRN_DETAIL
    {
        public int idGRNLinees { get; set; }
        public Nullable<int> iGRNID { get; set; }
        public Nullable<int> iPOID { get; set; }
        public Nullable<int> idPOLine { get; set; }
        public Nullable<int> iArticleID { get; set; }
        public string cArticleDescription2 { get; set; }
        public Nullable<decimal> dQuantityOrder { get; set; }
        public Nullable<decimal> bQuantityReceived { get; set; }
        public Nullable<decimal> dQuantity { get; set; }
        public Nullable<decimal> dUnitPrice { get; set; }
        public Nullable<decimal> dNetValue { get; set; }
        public Nullable<decimal> dTaxRate { get; set; }
        public Nullable<decimal> dTaxValue { get; set; }
        public Nullable<decimal> dGrossValue { get; set; }
        public Nullable<decimal> dValue { get; set; }
        public virtual GRN_HEADER grn { get; set; }
    }
}
