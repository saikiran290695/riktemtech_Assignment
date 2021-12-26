using RiktamTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace RiktamTech.DTO
{
    public class DecodedToken
    {
        public IIdentity decodedUser { get; set; }
        public int responseCode { get; set; }
        public string responseMgs { get; set; }

    }
}