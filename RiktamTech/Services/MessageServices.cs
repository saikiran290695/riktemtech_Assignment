using RiktamTech.DTO;
using RiktamTech.IServices;
using RiktamTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.Services
{
    public class MessageServices : IMessageServices
    {
        public bool SendMessages(Message mgs, int fromId)
        { 
            if(mgs == null)
                return false;

            try
            {
                databaseContext db = new databaseContext();
                db.userMessages.Add(
                    new USER_MESSAGES()
                    {
                        MESSAGE = mgs.message,
                        TO_ID = mgs.id,
                        FROM_ID = fromId,
                        CREATED_ON = DateTime.Now
                    }
                );

                db.SaveChanges();
            }
            catch (Exception ex) {
                return false;
            }

            return true;
        }

        public MessagesDTO RetriveMessages(int userID) { 
            MessagesDTO mgs = new MessagesDTO();
            databaseContext db = new databaseContext();            

            mgs.individualMessages = new List<Message>();
            
            var query = (from um in db.userMessages
                        join u in db.users
                        on um.FROM_ID equals u.ID
                        where um.TO_ID == userID
                        select new Message
                        {
                            id = u.ID,
                            handler = u.HANDLER,
                            message = um.MESSAGE
                        }).ToList();

            mgs.individualMessages.AddRange(query);

            mgs.groupMessages = new List<Message>();
            
            query = (from gm in db.groupMessages
                    join ug in db.userGroups
                    on gm.GROUP_ID equals ug.GROUPID
                    join u in db.users
                    on ug.USERID equals u.ID
                     where ug.USERID == userID
                    select new Message { 
                    id = u.ID,
                    handler = u.HANDLER,
                    message = gm.MESSAGE
                    }).ToList();

            mgs.groupMessages.AddRange(query);

            return mgs;
        }

        public bool SendMessage(GroupDTO group)
        {

            if (group == null)
                return false;
            try
            {
                databaseContext db = new databaseContext();
                db.groupMessages.Add(
                    new GROUP_MESSAGES()
                    {
                        GROUP_ID = group.groupId,
                        FROM_ID = group.currentUserId,
                        MESSAGE = group.message,
                        CREATED_ON = DateTime.Now
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