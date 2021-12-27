using RiktamTech.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.IServices
{
    public interface IUserServices
    {
        bool SignUpUser(UsersDTO user);

        bool UpdateUser(UsersDTO user);

        bool DeleteUser(string userHanler);

        UsersDTO GetUserDetails(string handler);
    }
}