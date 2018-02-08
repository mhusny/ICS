using System;
using System.Collections.Generic;

namespace ICS.Models
{
    public partial class ORDER_HEADER
    {
        public ORDER_HEADER()
        {
            details = new List<ORDER_DETAIL>();
        }
        public int iPOID { get; set; }
        public System.DateTime dDate { get; set; }
        public string cReference { get; set; }
        public int iFactoryID { get; set; }
        public int iSupplierID { get; set; }
        public string cSupplierCode { get; set; }
        public virtual SUPPLIER supplier { get; set; }
        public string cRemarks { get; set; }
        public bool bRecieved { get; set; }
        public bool bDeleted { get; set; }
        public virtual ICollection<ORDER_DETAIL> details { get; set; }
    }
}
