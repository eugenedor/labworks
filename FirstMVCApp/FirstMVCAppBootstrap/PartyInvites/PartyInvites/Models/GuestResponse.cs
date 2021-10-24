using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please indicate whether to take part in a party")]
        public bool? WillAttend { get; set; }
    }
}