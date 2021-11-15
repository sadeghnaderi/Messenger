using Messenger.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Entities
{
    public class Group
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("User")]
        public string AdminId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public bool IsChannel { get; set; }

        [ForeignKey("Message")]
        public int PinMessageId { get; set; }
        public virtual Message Message { get; set; }
    }
}
