using RiktamTech.DTO;
using RiktamTech.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;

namespace RiktamTech.IServices
{
    public interface IAuthServices
    {
        string GenerateJWTToken(USERS user);
        DecodedToken ValidateJWTToken(string token);
        JwtPayload DecryptJWTToken(string token);
        int GetCurrentUserId(string token);
    }
}