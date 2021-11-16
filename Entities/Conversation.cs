using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Entities
{
    public class Conversation
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string SenderId { get; set; }
        public virtual User User { get; set; }
        public string ReceiverId { get; set; }

        [ForeignKey("ReceiverType")]
        public int ReceiverTypeId { get; set; }
        public virtual ReceiverType ReceiverType { get; set; }

        public bool Active { get; set; }
    }
}
