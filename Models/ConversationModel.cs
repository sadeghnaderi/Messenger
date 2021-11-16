using Messenger.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class ConversationModel
    {
        public string ReceiverId { get; set; }
        public int ReceiverTypeId { get; set; }

        public string Name { get; set; }
    }
}
