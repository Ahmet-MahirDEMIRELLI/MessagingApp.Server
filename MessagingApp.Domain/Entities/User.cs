using System.ComponentModel.DataAnnotations;

namespace MessagingApp.Domain.Entities
{
    public class User
    {
        public User(string nickname, string x25519PublicKey, string ed25519PublicKey, DateTime createdAt)
        {
            Nickname = nickname;
            X25519PublicKey = x25519PublicKey;
            Ed25519PublicKey = ed25519PublicKey;
            CreatedAt = createdAt;
        }

        public User() { }

        [Key]
        public string Nickname { get; set; }
        public string X25519PublicKey { get; set; } = string.Empty;
        public string Ed25519PublicKey { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
