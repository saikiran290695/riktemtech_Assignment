using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.DTO
{
    public class ServiceResponse
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }
}