using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.DTO
{
    public class GroupDTO
    {
        public int currentUserId { get; set; }
        public int groupId { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public List<int> membersId { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        public string message { get; set; }

    }
}