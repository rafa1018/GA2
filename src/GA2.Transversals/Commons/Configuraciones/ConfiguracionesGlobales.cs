namespace GA2.Transversals.Commons
{
    /// <summary>
    /// Configuracion de email aplicacion
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>05/05/2021</date>
    public class EmailOptions
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Configuracion de  Aplicacion Main
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>05/05/2021</date>
    public class AppMainOptions
    {
        public string Hash { get; set; }
        public string PhraseKey { get; set; }
        public string ApplicationName { get; set; }
        public string Password { get; set; }
        public string ApplicationId { get; set; }
    }

    /// <summary>
    /// Configuracion de Caja Honor Keys
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>05/05/2021</date>
    public class CHKeysOptions
    {
        public string UrlCajaHonor { get; set; }
        public string LoginCajaHonor { get; set; }
        public string GetChGuid { get; set; }
        public string NombreAplicacion { get; set; }
        public string PhraseKey { get; set; }
        public string HashAplicacion { get; set; }
        public string Token { get; set; }
        public string User { get; set; }
    }

    /// <summary>
    /// Configuracion de direccion Apis
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>05/05/2021</date>
    public class ApisOptions
    {
        public string BUA { get; set; }
        public string GA2 { get; set; }
        public string IDENTITY { get; set; }
        public string LoginExternal { get; set; }
    }

    /// <summary>
    /// Configuracion de JSON WEB TOKENS
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>05/05/2021</date>
    public class JwtOptions
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string TypeDocumentExtension { get; set; }
        public string VersionApi { get; set; }
        public string Digest { get; set; }
    }

    /// <summary>
    /// Configuracion de IDVISION
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>05/05/2021</date>
    public class IdVisionOptions
    {
        public string usuarioIDVision { get; set; }
        public string claveIDVision { get; set; }
        public string solucionId { get; set; }
    }

    /// <summary>
    /// Configuracion Accesso AQM
    /// </summary>
    public class AqmOptions
    {
        public string usuarioAqm { get; set; }
        public string claveAqm { get; set; }
        public string solucionIdAqm { get; set; }
    }

    /// <summary>
    /// Configuracion de blobstorage
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class BlobStorageOptions
    {
        public string CadenaOne { get; set; }
        public string KeyOne { get; set; }
    }
    
    /// <summary>
    /// Configuracion de containers del blobstorage
    /// </summary>
    /// <author>Sergio Ortega Fula</author>
    public class ContainersBlobStorage
    {
        public string ContainerPagoMasivo { get; set; }
        public string BaseFilePagoMasivo { get; set; }
        public string RecursiveFilePagoMasivo { get; set; }
        public string StyleFilePagomasivo { get; set; }
    }

    /// <summary>
    /// Configuracion de colas de peticiones
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>22/05/2021</date>
    public class ConfigsQueueOptions
    {
        public string UserQueue { get; set; }
        public string PasswordQueue { get; set; }
    }
}
