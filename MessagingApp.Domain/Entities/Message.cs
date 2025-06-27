using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Domain.Entities
{
    public class Message
    {
        public Message(string sender, string receiver, string content, DateTime timestamp)
        {
            Sender = sender;
            Receiver = receiver;
            Content = content;
            Timestamp = timestamp;
        }

        public Message() { }

        [Key]
        public string Sender { get; set; }

        public string Receiver { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
