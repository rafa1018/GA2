using System;
using System.Security.Cryptography;
using System.Text;

namespace GA2.Application.Main
{
    /// <summary>
    /// Cryptografia GA2
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>30/02/2021</date>
    public class CryptoGA2 : ICryptoGA2
    {
        /// <summary>
        /// Decryptar cadena
        /// </summary>
        /// <param name="cipherString">Cipher de configuracion</param>
        /// <param name="pKey">Clave secreta</param>
        /// <param name="useHashing">Hash de configuracion aplicacion</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>30/04/2021</date>
        /// <returns>Cadena decryptada</returns>
        public string DecryptMD5(string cipherString, string pKey, bool useHashing = true)
        {
            byte[] array = Convert.FromBase64String(cipherString);

            byte[] key;

            if (useHashing)
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(pKey));
                mD5CryptoServiceProvider.Clear();
            }
            else
            {
                key = Encoding.UTF8.GetBytes(pKey);
            }

            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
            byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            tripleDESCryptoServiceProvider.Clear();

            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Encryptar cadena clave
        /// </summary>
        /// <param name="toEncrypt">Cadena a encryptar</param>
        /// <param name="pKey">Clave clave secreta</param>
        /// <param name="useHashing">Hash de configuracion</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>30/04/2021</date>
        /// <returns>Cadena encryptada</returns>
        public string EncryptMD5(string toEncrypt, string pKey, bool useHashing = true)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
            byte[] key;

            if (useHashing)
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(pKey));
                mD5CryptoServiceProvider.Clear();
            }
            else
            {
                key = Encoding.UTF8.GetBytes(pKey);
            }

            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
            byte[] array = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            tripleDESCryptoServiceProvider.Clear();

            return Convert.ToBase64String(array, 0, array.Length);
        }

        /// <summary>
        /// Generador cadena hash 
        /// </summary>
        /// <param name="pCadenaString">Cadena que se convertirar en hash</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>30/04/2021</date>
        /// <returns>Cadena en formato hash</returns>
        public string GenerarHashString(string pCadenaString)
        {
            using MD5 mD = MD5.Create();
            return BitConverter.ToString(mD.ComputeHash(Encoding.UTF8.GetBytes(pCadenaString))).Replace("-", string.Empty);
        }
    }
}
