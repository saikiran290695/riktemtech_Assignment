using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiktamTech.DTO
{
    public class Message
    {
        public int id { get; set; }
        public string handler { get; set; }
        public string message { get; set; }
    }

    public class MessagesDTO { 
    
        public List<Message> individualMessages { get; set; }
        public List<Message> groupMessages { get; set; }
    
    }
}