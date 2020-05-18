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
            ContentMD5();
        }

        private static void ContentMD5()
        {
            var str = "Hello World!";
            var data = Encoding.UTF8.GetBytes(str);
            var md5 = MD5Encrypt.GetEncryptData(data);
            var base64 = Convert.ToBase64String(md5);
            Console.WriteLine(base64);

            var bas64 = MD5Encrypt.GetContentMD5(str);
            Console.WriteLine(bas64);
        }
    }
}
