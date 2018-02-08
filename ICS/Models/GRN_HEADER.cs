using System;
using System.Collections.Generic;

namespace ICS.Models
{
    public partial class GRN_HEADER
    {
        public GRN_HEADER()
        {
            grndetails = new List<GRN_DETAIL>();
        }
        public int iGRNID { get; set; }
        public System.DateTime dDate { get; set; }
        public string cReference { get; set; }
        public int iPOID { get; set; }
        public int iFactoryID { get; set; }
        public string cRemarks { get; set; }
        public bool bReceived { get; set; }
        public decimal dValue { get; set; }
        public bool bUpdated { get; set; }
        public bool bDeleted { get; set; }
        public virtual ICollection<GRN_DETAIL> grndetails { get; set; }
    }
}
