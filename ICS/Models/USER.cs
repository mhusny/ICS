using System;
using System.Collections.Generic;

namespace ICS.Models
{
    public partial class USER
    {
        public int iAutoIndex { get; set; }
        public string cUserName { get; set; }
        public int iFactoryID { get; set; }
        public bool bActive { get; set; }
        public bool bAdmin { get; set; }
        public string cComputer { get; set; }
        public string cPassword { get; set; }
    }
}
