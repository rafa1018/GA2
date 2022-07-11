namespace GA2.Transversals.Commons.Constants
{
    /// <summary>
    /// Constantes de Identity
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>22/10/2021</date>
    public static class IdentityConstants
    {
        public const string ApiName = "GA2Identity";

        public const string GetOpenApiInfoDescription = "Tool to manage the GA2.Identity business center";

        public const string GetOpenApiSecuritySchemeDescription = "JWT Authorization header using the Bearer scheme.\n\n" +
                      "Enter 'Bearer' [space] and then your token in the text input below.\n" +
                      "Example: 'Bearer 12345abcdef'";

        public const string GetOpenApiSecuritySchemeName = "Authorization";

        public const string UsuarioInvalido = "Usuario y constraseña invalidos";

        public const string LoginInvalidoPaa = "Datos del cliente invalidos";

        public const string LoginRecuperaContrasena = "Se envió un coreo electrónico con un enlace para restablecer tu contraseña";
    }
}
