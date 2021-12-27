using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RiktamTech.DTO
{
    public class UsersDTO
    {
        public int id { get; set; }
        public string handler { get; set; }
        public string name { get; set; }        
        public string email { get; set; }
        public int phone { get; set; }
        public string password { get; set; }
        public string password_hint { get; set; }
    }
}