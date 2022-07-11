namespace GA2.Transversals.Commons.Constants.Apis
{
    /// <summary>
    /// Constantes de Producto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public class ProductoConstants
    {
        public const string ApiName = "GA2Producto";

        public const string GetOpenApiInfoDescription = "Tool to manage the Products";

        public const string GetOpenApiSecuritySchemeDescription = "JWT Authorization header using the Bearer scheme.\n\n" +
                      "Enter 'Bearer' [space] and then your token in the text input below.\n" +
                      "Example: 'Bearer 12345abcdef'";

        public const string GetOpenApiSecuritySchemeName = "Authorization";
    }
}
