using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Check
{
    public class HJ212CRC16Check
    {
        public static string CRC16Checkout(byte[] puchMsg)
        {
            uint i, j, crc_reg, check;
            crc_reg = 0xFFFF;
            for (i = 0; i < puchMsg.Length; i++)
            {
                crc_reg = (crc_reg >> 8) ^ puchMsg[i];
                for (j = 0; j < 8; j++)
                {
                    check = crc_reg & 0x0001;
                    crc_reg >>= 1;
                    if (check == 0x0001)
                    {
                        crc_reg ^= 0xA001;
                    }
                }
            }
            return crc_reg.ToString("X").PadLeft(4, '0');//PadLeft填充字符串左边，4为字符串总长度，0为填充符，即E40==>0E40
        }
    }
}
