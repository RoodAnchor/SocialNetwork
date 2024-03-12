using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class MessageSendingData
    {
        public Int32 SenderId { get; set; }
        public String Content { get; set; }
        public String RecipientEmail { get; set; }
    }
}
