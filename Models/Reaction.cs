using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class Reaction
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string MessageReaction { get; set; }
    }
}
