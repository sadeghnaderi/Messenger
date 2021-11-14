using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is requierd")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is requierd")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is requierd")]
        public string Password { get; set; }

    }
}
