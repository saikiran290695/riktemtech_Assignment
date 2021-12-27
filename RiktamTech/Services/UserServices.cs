using RiktamTech.DTO;
using RiktamTech.IServices;
using RiktamTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RiktamTech.Services
{
    public class UserServices : IUserServices
    {
        public bool SignUpUser(UsersDTO user)
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

        public bool UpdateUser(UsersDTO user) {

            if (user == null)
                return false;

            try
            {
                databaseContext db = new databaseContext();
                USERS oldUser = db.users.Where(x => x.HANDLER == user.handler).FirstOrDefault();

                if (oldUser == null)
                    return false;

                oldUser.NAME = user.name;
                oldUser.EMAIL = user.email;
                oldUser.PHONE = user.phone;

                db.SaveChanges();

            }
            catch (Exception ex) {
                return false;
            }            

            return true;
        }

        public bool DeleteUser(string userHandler) {

            if (userHandler == null)
                return false;

            try
            {
                databaseContext db = new databaseContext();

                // remove user from user table                
                USERS oldUser = db.users.Where(x => x.HANDLER == userHandler).FirstOrDefault();
                List<USER_MESSAGES> userMessages = db.userMessages.Where(x => x.FROM_ID == oldUser.ID).ToList();
                List<GROUP_MESSAGES> groupMessages = db.groupMessages.Where(x => x.FROM_ID == oldUser.ID).ToList();
                List<USERGROUPS> groups = db.userGroups.Where(x => x.USERID == oldUser.ID).ToList();

                // delete users footprint
                db.users.Remove(oldUser);
                db.userGroups.RemoveRange(groups);
                db.userMessages.RemoveRange(userMessages);
                db.groupMessages.RemoveRange(groupMessages);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public UsersDTO GetUserDetails(string handler)
        {
            databaseContext db = new databaseContext();
            
            return db.users.Where(x => x.HANDLER == handler).Select(y => new UsersDTO
            {
                id = y.ID,
                name = y.NAME,
                handler = y.HANDLER,
                email = y.EMAIL,
                phone = y.PHONE,                
            }).FirstOrDefault();
        }

    }
}