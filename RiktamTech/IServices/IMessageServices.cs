using RiktamTech.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.IServices
{
    public interface IMessageServices
    {
        bool SendMessages(Message mgs, int fromId);
        MessagesDTO RetriveMessages(int userID);
        bool SendMessage(GroupDTO group);
    }
}