﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Symmetric.AES
{
    public class Aes128CbcProvider
    {
        public static string Encrypt(string plainText, string encryptKey)
        {
            //分组加密算法  
            SymmetricAlgorithm des = Rijndael.Create();

            var inputdata = Encoding.UTF8.GetBytes(plainText);
            byte[] inputByteArray = inputdata;//得到需要加密的字节数组      
                                              //设置密钥及密钥向量
            des.Key = Encoding.UTF8.GetBytes(encryptKey);
            des.IV = new byte[16];
            // 生成随机的Inilization Vector
            //des.GenerateIV();

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    byte[] cipherBytes = ms.ToArray();//得到加密后的字节数组  
                    cs.Close();
                    ms.Close();
                    return Convert.ToBase64String(cipherBytes);
                }
            }
        }

        public static string Decrypt(string cipher, string encryptKey)
        {
            var inputData = Convert.FromBase64String(cipher);
            SymmetricAlgorithm des = Rijndael.Create();
            des.Key = Encoding.UTF8.GetBytes(encryptKey);
            var iv = new byte[16];
            //Array.Copy(inputData, iv, 16);
            des.IV = iv;

            byte[] decryptBytes = new byte[inputData.Length];
            using (MemoryStream ms = new MemoryStream(inputData))
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(decryptBytes, 0, decryptBytes.Length);
                    cs.Close();
                    ms.Close();
                }
            }

            return Encoding.UTF8.GetString(decryptBytes);
        }
    }
}
