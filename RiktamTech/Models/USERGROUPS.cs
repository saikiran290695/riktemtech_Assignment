using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.Models
{
    public class USERGROUPS
    {
        public int ID { get; set; }
        public int USERID { get; set; }
        public int GROUPID { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }

    }
}