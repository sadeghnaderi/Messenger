using Library.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Models
{
    public class GroupUsers
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("Group")]
        public string GroupId { get; set; }
        public virtual Group Group { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
