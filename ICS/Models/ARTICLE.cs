using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICS.Models
{
    public partial class ARTICLE
    {
        public int iArticleID { get; set; }
        public string cArticleCode { get; set; }
        public string cArticleDescription1 { get; set; }
        public string cArticleDescription2 { get; set; }
        [Required]
        public int iSeasonID { get; set; }
        public string cStyleDescription { get; set; }
        public bool bActive { get; set; }
        public string cUOM { get; set; }
        public decimal dQtyInStock { get; set; }
    }
}
