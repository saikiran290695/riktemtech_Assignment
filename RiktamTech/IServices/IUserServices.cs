using RiktamTech.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.IServices
{
    public interface IUserServices
    {
        bool SignUpUser(UserSignUp user);
    }
}