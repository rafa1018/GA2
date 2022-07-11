namespace GA2.Transversals.Commons.Constants
{
    /// <summary>
    /// Constantes de Solicitud
    /// </summary>
    /// <author>Erwin Pantoja España</author>
    public static class SolicitudConstants
    {
        //estado solicitud CAT_ID = 72
        public const int EstadoInicialSolicitud = 395; //CVL_DESCRIPCION En Tramite

        public const int EstadoAnuladaSolicitud = 396;

        public const int EstadoProcesadaSolicitud = 397;

        public const int EstadoInconsistenteSolicitud = 398;

        //estado solicitud tarea CAT_ID = 69
        public const int EstadoInicialTareaSolicitud = 327; //CVL_DESCRIPCION Pendiente

        public const int EstadoAprobadaTareaSolicitud = 328;

        public const int EstadoTramiteTareaSolicitud = 329;

        public const int EstadoSubsanacionTareaSolicitud = 330;

        public const int EstadoRechazadaTareaSolicitud = 399;


        public const string EstadoInicialTarea = "Solicitud de retiro";

        //id estado tipo tercero CAT_ID = 71
        public const int TipoTerceroVendedorId = 333;

        public const int TipoTerceroBeneficiarioId = 334;

        public const int TipoTerceroApoderadoId = 335;

        public const int TipoTerceroConstructorId = 336;

        public const int TipoTerceroEntidadEducativa = 400;

        public const int TipoTerceroBeneficiarioEstudioId = 401;

        public const int TipoTerceroEntidadSeguroEducativoId = 402;

        public const int TipoTerceroTenedorAccionesId = 403;

        public const int TipoTerceroBeneficiarioEstudioEntidadEducativaId = 404; //no está en BD

        public const int TipoIdentificacionNit = 2;
    }
}
