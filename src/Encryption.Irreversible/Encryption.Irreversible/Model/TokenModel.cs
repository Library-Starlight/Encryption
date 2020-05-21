using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Model
{
    public class TokenModel
    {
        public string userId { get; set; }
        public string nonce { get; set; }
    }
}
