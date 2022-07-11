namespace GA2.Application.Main
{
    /// <summary>
    /// Interface Injectable
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>30/04/2021</date>
    public interface ICryptoGA2
    {
        /// <summary>
        /// Decriptador de cadenas
        /// </summary>
        /// <param name="cipherString">Cadena encriptada</param>
        /// <param name="pKey">Palabra secreta de configuraciones</param>
        /// <param name="useHashing">Uso hash por default</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>30/04/2021</date>
        /// <returns>Cadena desencryptada</returns>
        string DecryptMD5(string cipherString, string pKey, bool useHashing = true);

        /// <summary>
        /// Encryptador de cadenas
        /// </summary>
        /// <param name="toEncrypt">Cadena a encryptar</param>
        /// <param name="pKey">Clave secreta</param>
        /// <param name="useHashing">Uso de hash por default</param>
        /// <returns></returns>
        string EncryptMD5(string toEncrypt, string pKey, bool useHashing = true);
        string GenerarHashString(string pCadenaString);
    }
}