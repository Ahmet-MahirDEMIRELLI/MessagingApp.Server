using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Infrastructure.Interfaces
{
    public interface ISignatureRepository
    {
        bool Verify(string data, byte[] signature, byte[] publicKey);
    }
}
