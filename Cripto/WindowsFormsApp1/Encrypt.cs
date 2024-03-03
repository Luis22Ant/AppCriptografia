using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Encrypt : Cryptography
    {
        public static string EncryptData(dynamic Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESkey = HashProvider.ComputeHash(UTF8.GetBytes(ENCRYPTKEY));
            TripleDESCryptoServiceProvider TDESAlgoritm = new TripleDESCryptoServiceProvider();
            TDESAlgoritm.Key = TDESkey;
            TDESAlgoritm.Mode = CipherMode.ECB;
            TDESAlgoritm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgoritm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);

            }
            finally
            {
                TDESAlgoritm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);

        }
    }
}
