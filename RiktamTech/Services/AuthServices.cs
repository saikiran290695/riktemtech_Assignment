using Microsoft.IdentityModel.Tokens;
using RiktamTech.DTO;
using RiktamTech.IServices;
using RiktamTech.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RiktamTech
{

    public class AuthServices: IAuthServices
    {
        public string securityKey = "somethingsomethingsomethingsomethingsomethingsomethingsomethingsomethingsomethingsomething";
        
        public string GenerateJWTToken(USERS user)
        {
            var claims = new[] {
                new Claim("Name", user.NAME),
                new Claim("ID",user.ID.ToString()),
                new Claim("Email",user.EMAIL),
                new Claim("HANDLER",user.HANDLER),
                new Claim("PHONE",user.PHONE.ToString()),
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = new JwtSecurityToken( 
                issuer: "riktemtech",
                claims: claims,
                expires: DateTime.Now.AddDays(7), 
                signingCredentials : new SigningCredentials(
                        new SymmetricSecurityKey( Encoding.UTF8.GetBytes(securityKey) ),
                        SecurityAlgorithms.HmacSha512)
                );

            return tokenHandler.WriteToken(token);
        }

        public DecodedToken ValidateJWTToken(string token)
        {            
            var key = Encoding.ASCII.GetBytes(securityKey);
            var handler = new JwtSecurityTokenHandler();

            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = false,
                ValidateIssuer = false
            };

            DecodedToken decodedToken = new DecodedToken();

            try
            {
                var data = handler.ValidateToken(token, validations, out var tokenSecure).Identity;                
                decodedToken.decodedUser = data;
                decodedToken.responseCode = 200;
                decodedToken.responseMgs = "success";
            }
            catch (Exception ex)
            {
                decodedToken.decodedUser = null;
                decodedToken.responseCode = 401;
                decodedToken.responseMgs = ex.Message;                
            }
            
            return decodedToken;
        }

        public JwtPayload DecryptJWTToken(string token)
        { 
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(token).Payload;            
        }

        public int GetCurrentUserId(string token)
        {
            JwtPayload payload = DecryptJWTToken(HttpContext.Current.Request.Headers.GetValues("token")[0]);
            payload.TryGetValue("ID", out var from_Id);
            return Convert.ToInt32(from_Id);
        }

    }
}