using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Domain.Entities
{
    public class User
    {
        public User(string nickname, string publicKey, DateTime lastActivityDate, DateTime createdAt)
        {
            Nickname = nickname;
            PublicKey = publicKey;
            LastActivityDate = lastActivityDate;
            CreatedAt = createdAt;
        }

        public User() { }

        [Key]
        public string Nickname { get; set; }

        public string PublicKey { get; set; } = string.Empty;

        public DateTime LastActivityDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
