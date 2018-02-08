using System;
using System.Collections.Generic;

namespace ICS.Models
{
    public partial class SUPPLIER
    {
        public int iSupplierID { get; set; }
        public string cSupplierCode { get; set; }
        public string cSupplierName { get; set; }
        public string cAddress1 { get; set; }
        public string cAddress2 { get; set; }
        public string cAddress3 { get; set; }
        public string cAddress4 { get; set; }
        public string cAddress5 { get; set; }
        public string cContactName { get; set; }
        public string cContactDetails { get; set; }
        public ICollection<ORDER_HEADER> orders { get; set; }
    }
}
