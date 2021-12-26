using RiktamTech.DTO;
using RiktamTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace RiktamTech.Services
{
    public class groupServices
    {
        public bool createGroup(groupDTO group)
        {
            if (group == null)
                return false;

            try
            {
                databaseContext db = new databaseContext();

                db.groups.Add(
                    new GROUPS()
                    {
                        NAME = group.name,
                        DESCRIPTION = group.description,
                        CREATED_BY = group.currentUserId,
                        CREATED_ON = DateTime.Now,                        
                        UPDATED_ON = null,
                        UPDATED_BY = null
                    });

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                
                return false;
            }
            return true;
        }

        public bool addUsersToGroup(groupDTO group)
        {
            if (group == null)
                return false;

            try
            {
                databaseContext db = new databaseContext();
                List<USERGROUPS> ug = new List<USERGROUPS>();
                group.membersId.ForEach(
                    x => {
                        ug.Add(new USERGROUPS()
                        {
                            USERID = x,
                            GROUPID = group.groupId,
                            CREATED_BY = group.currentUserId,
                            CREATED_ON = DateTime.Now
                        }
                        );
                    }
                );

                db.userGroups.AddRange(ug);

                db.SaveChanges();
            }

            catch (Exception ex) {
                return false;
            }

            return true;
        }

        
    }
}