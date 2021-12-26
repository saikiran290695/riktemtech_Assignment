using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.Models
{
    public class GROUPS
    {
        public int ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string NAME { get; set; }
        public DateTime CREATED_ON { get; set; }
        public DateTime? UPDATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public int? UPDATED_BY { get; set;}
    }
}