﻿using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using RiktamTech.DTO;
using RiktamTech.IServices;
using RiktamTech.Models;
using RiktamTech.Services;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using Unity;
using static System.Net.WebRequestMethods;

namespace RiktamTech.Controllers
{    
    public class UsersController : ApiController
    {
        private IAuthServices _authServices = DependencyInjection.Unity.container.Resolve<IAuthServices>();
        private IUserServices _userServices = DependencyInjection.Unity.container.Resolve<IUserServices>();

        [HttpPost]
        public string login()
        {                        
            JObject req = JObject.Parse(Request.Content.ReadAsStringAsync().Result);
            
            string username = req.GetValue("Handler").ToString();
            string password = req.GetValue("Password").ToString();
            
            var password_bytes = Encoding.UTF8.GetBytes(password);

            SHA512 sha = new SHA512CryptoServiceProvider();
            var coded = BitConverter.ToString(sha.ComputeHash(password_bytes));

            databaseContext db = new databaseContext();
            USERS user = db.users.Where(x => x.HANDLER == username && x.PASSWORD == coded).FirstOrDefault();
            string token = string.Empty;
            
            if (user != null)
            {                
                token = _authServices.GenerateJWTToken(user);
            }

            return token;
        }

        [HttpPost]
        [Route("api/users/signup")]
        public IHttpActionResult userSignUp(UserSignUp user) {            
                        
            if (!_userServices.SignUpUser(user))
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpGet()]
        [Route("api/users/getdetails")]
        public JwtPayload getTokenDetails() {
            
            string token = Request.Headers.Where( x => x.Key == "token").SingleOrDefault().Value.FirstOrDefault();            

            JwtPayload claims = _authServices.DecryptJWTToken(token);

            return claims;
        }

    }
}
