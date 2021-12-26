using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.Models
{
    public class USERS
    {
        public int ID { get; set; } 
        public string NAME { get; set; }    
        public string HANDLER { get; set; }
        public string EMAIL { get; set; }
        public int PHONE { get; set; }
        public string PASSWORD { get; set; }
        public string PASSWORD_HINT { get; set; }
        public DateTime CREATED_ON  { get; set; }

    }
}