using RiktamTech.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RiktamTech.Services
{
    public class UserServices
    {
        public bool signUpUser(UserSignUp user)
        { 
            if(user == null)
                return false;
            
            try
            {
                databaseContext db = new databaseContext();

                var password_bytes = Encoding.UTF8.GetBytes(user.password);

                SHA512 sha = new SHA512CryptoServiceProvider();
                var coded = BitConverter.ToString(sha.ComputeHash(password_bytes));


                db.users.Add(new Models.USERS()
                {
                    NAME = user.name,
                    EMAIL = user.email,
                    HANDLER = user.handler,
                    PASSWORD =   coded,
                    PASSWORD_HINT = user.password_hint,
                    PHONE = user.phone,
                    CREATED_ON = DateTime.Now,
                });

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            
            return true;
        }
    }
}