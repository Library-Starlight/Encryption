using AlarmCenter.DataCenter;
using Encryption.Irreversible.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Encryption
{
    /// <summary>
    /// 敢为MD5加密算法
    /// </summary>
    [Description("敢为MD5算法")]
    public class GWMD5Encryption : IEncrypt
    {
        public string Decrypt(string input)
        {
            return DataCenter.MD5Decrypt(input, DataCenter.GeneratMD5Key());
        }

        public string Encrypt(string input)
        {
            return DataCenter.MD5Encrypt(input, DataCenter.GeneratMD5Key());
        }
    }
}
