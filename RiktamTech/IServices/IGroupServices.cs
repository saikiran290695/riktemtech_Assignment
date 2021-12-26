using RiktamTech.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.IServices
{
    public interface IGroupServices
    {
        bool CreateGroup(GroupDTO group);
        bool AddUsersToGroup(GroupDTO group);
    }
}