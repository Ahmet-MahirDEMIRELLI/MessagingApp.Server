using MessagingApp.Infrastructure.Interfaces;
using MessagingApp.Infrastructure.Persistence;
using NSec.Cryptography;
using System.Text;

namespace MessagingApp.Infrastructure.Repositories
{
    public class SignatureRepository : ISignatureRepository
    {
        protected readonly AppDbContext _context;
        public SignatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Verify(string data, byte[] signature, byte[] publicKey)
        {
            try
            {
                var algorithm = SignatureAlgorithm.Ed25519;
                var publicKeyObj = PublicKey.Import(algorithm, publicKey, KeyBlobFormat.RawPublicKey);
                var dataBytes = Encoding.UTF8.GetBytes(data);
                return algorithm.Verify(publicKeyObj, dataBytes, signature);
            }
            catch
            {
                return false;
            }
        }
    }
}
