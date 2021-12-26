using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.Models
{
    public class GROUP_MESSAGES
    {
        public int ID { get; set; }
        public int GROUP_ID { get; set; }
        public int FROM_ID { get; set; }
        public string MESSAGE { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}