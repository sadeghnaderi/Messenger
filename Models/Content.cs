using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class Content
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string MessageContent { get; set; }
    }
}
