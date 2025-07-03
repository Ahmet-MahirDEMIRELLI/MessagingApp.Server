using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Application.DTOs
{
    public class SendMessageDto
    {
        [Required]
        public string Sender { get; set; }
        [Required]
        public string Receiver { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Signature { get; set; }
    }
}
