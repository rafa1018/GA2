namespace GA2.Transversals.Commons
{
    /// <summary>
    /// COnstantes de providerrequest
    /// </summary>
    /// <author>Oscar Julian ROjas</author>
    /// <date>06/05/2021</date>
    public static class RequestProviderConstants
    {
        /// <summary>
        /// Url login de ga2 a Bua
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>22/05/2021</date>
        public const string UrlLoginGA2Paa =
            "clientes/ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular?TipoDocumento={0}&NumeroIdentificacion={1}&NumeroCelular={2}&FechaExpedicion={3}";

        /// <summary>
        /// Url api bua validar clientes no creados
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>22/05/2021</date>
        public const string ApiBuaValidarClientes = "validarClientes";


        /// <summary>
        /// Url api bua obtener cliente
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public const string ObtenerInformacionClientePorDocumentoYTipo = "clientes/ObtenerInformacionClientePorDocumentoYTipo";

        /// <summary>
        /// Url api bua obtener cliente
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public const string ObtenerClienteInformacion = "clientes";

        /// <summary>
        /// Url api bua obtener cliente por cedula
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public const string ObtenerInformacionClienteCedula = "clientes/ObtenerInformacionClienteCedula";

        /// <summary>
        /// Url api login username password
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>25/11/2021</date>
        public const string LoginExternalRequest = "api/login/external";

        public const string ObtenerCuentaById = "api/clientes/ObtenerCuentaById";

        public const string ObtenerClientePorTipoIdentificationYNumero = "clientes/obtenerclienteportipoidentificationynumero";

        public const string ObtenerCuentaClieteByIdNumeroCuenta = "clientes/ObtenerCuentaClieteByIdNumeroCuenta";

        public const string ObtenerClientesById = "clientes/ObtenerClientesById";

        public const string ObtenerInformacionByCedula = "clientes/ObtenerInformacionByCedula";



        public const string ObtenerCuentaIdCuenta = "ObtenerCuentaIdCuenta";

        public const string ObtenerInformacionCliente = "ObtenerDatosAdministracionCuentas";

        /// <summary>
        /// Url api bua CierreMensual
        /// </summary>
        /// <author>Edwin Lopez</author>
        /// <date>05/05/2022</date>
        public const string CierreMensual = "CierreMensual";

        /// <summary>
        /// Url api bua ConsultarProgramacionCierreMensual
        /// </summary>
        public const string ConsultarProgramacionCierreMensual = "ConsultarProgramacionCierreMensual";


        /// <summary>
        /// Url api bua CierreAnual
        /// </summary>
        public const string CierreAnual = "CierreAnual";


        /// <summary>
        /// ConsultarProgramacionCierreAnual
        /// </summary>
        public const string ConsultarProgramacionCierreAnual = "ConsultarProgramacionCierreAnual";

        /// <summary>
        /// ReporteCierreMensual
        /// </summary>
        public const string ReporteCierreMensual = "ReporteCierreMensual";


        /// <summary>
        /// ObtenerCuentasClienteId
        /// </summary>
        public const string ObtenerCuentasClienteId = "ObtenerCuentasClienteId";

    }
}
