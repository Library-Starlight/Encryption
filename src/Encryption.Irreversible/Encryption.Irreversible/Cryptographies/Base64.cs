using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible
{
    public class Base64
    {
        public static string Encrypt(byte[] data) => Convert.ToBase64String(data);
    }
}
