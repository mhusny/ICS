using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ICS.Models
{
    public partial class ORDER_DETAIL
    {
        public int idPOLine { get; set; }
        public int iPOID { get; set; }
        [Required]
        public int iArticleID { get; set; }
        public string cArticleDescription2 { get; set; }
        public Nullable<decimal> dOrderQuantity { get; set; }
        public Nullable<decimal> dRecievedQuantity { get; set; }
        public Nullable<decimal> dUnitPrice { get; set; }
        public Nullable<decimal> dValue { get; set; }
        public virtual ORDER_HEADER order { get; set; }
    }
}
