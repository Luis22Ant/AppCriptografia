using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Decrypt : Cryptography
    {
        public static string DecryptData(dynamic Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESkey = HashProvider.ComputeHash(UTF8.GetBytes(ENCRYPTKEY));
            TripleDESCryptoServiceProvider TDESAlgoritm = new TripleDESCryptoServiceProvider();
            TDESAlgoritm.Key = TDESkey;
            TDESAlgoritm.Mode = CipherMode.ECB;
            TDESAlgoritm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform Decryptor = TDESAlgoritm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);

            }
            finally
            {
                TDESAlgoritm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);

        }
    }
}
