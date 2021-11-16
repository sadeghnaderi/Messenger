using Messenger.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Entities
{
    public class Message
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

        [Required]
        public string Content { get; set; }

        [ForeignKey("ContentType")]
        public int ContentTypeId { get; set; }
        public virtual ContentType ContentType { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public bool IsForwarded { get; set; }

        [ForeignKey("ForwardedFromUser")]
        public string ForwardedFromId { get; set; }
        public virtual User ForwardedFromUser { get; set; }

        [Required]
        public bool IsUserSeen { get; set; }

        public bool HasReaction { get; set; }

        [ForeignKey("Reaction")]
        public int ReactionId { get; set; }
        public virtual Reaction Reaction { get; set; }

        public bool IsDeleted { get; set; }

    }
}
