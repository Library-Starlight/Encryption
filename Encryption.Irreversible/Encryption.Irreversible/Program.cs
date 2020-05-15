using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible
{
    class Program
    {
        static void Main(string[] args)
        {
            var md5Str = MD5Encrypt.Encrypt("user_12345");
            Console.WriteLine(md5Str);

            md5Str = MD5Encrypt.Encrypt1("user_12345");
            Console.WriteLine(md5Str);
        }
    }
}
