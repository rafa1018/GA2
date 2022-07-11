namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Query string Solicitud Simulacion base Datos
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public static class SolicitudSimulacionQuery
    {
        public const string QueryGetAllSolicitudSimulacion = @"SELECT SLS_ID, SLS_FECHA_SOLICITUD, TCR_ID, TCR_NUMERO_PREAPROBADO, SLS_PROBLEMA_EMAIL,
                                                                      SLS_ENVIO_NOTIFICACION, SLS_ESTADO, SLS_USUARIO_ACTUALIZA, SLS_FECHA_ACTUALIZA
                                                                 FROM SLS_SOLICITUD_SIMULACION;";

        public const string QueryGetById = @"SELECT SLS_ID, SLS_FECHA_SOLICITUD, TCR_ID, TCR_NUMERO_PREAPROBADO, SLS_PROBLEMA_EMAIL,
                                                      SLS_ENVIO_NOTIFICACION, SLS_ESTADO, SLS_USUARIO_ACTUALIZA, SLS_FECHA_ACTUALIZA
                                                 FROM SLS_SOLICITUD_SIMULACION
                                                WHERE SLS_ID=@SLS_ID;";

        public const string QueryInsertSolicitudSimulacion = @"Insert into SLS_SOLICITUD_SIMULACION
                                                 (SLS_ID, SLS_FECHA_SOLICITUD, TCR_ID, TCR_NUMERO_PREAPROBADO, SLS_PROBLEMA_EMAIL,
                                                  SLS_ENVIO_NOTIFICACION, SLS_ESTADO, SLS_USUARIO_ACTUALIZA, SLS_FECHA_ACTUALIZA)
                                        VALUES(@SLS_ID, @SLS_FECHA_SOLICITUD, @TCR_ID, @TCR_NUMERO_PREAPROBADO, @SLS_PROBLEMA_EMAIL,
                                               @SLS_ENVIO_NOTIFICACION, @SLS_ESTADO, @SLS_USUARIO_ACTUALIZA, @SLS_FECHA_ACTUALIZA);" + QueryGetById;


        public const string QueryUpdateSolicitudSimulacion = @"UPDATE SLS_SOLICITUD_SIMULACION
                                                SET TCR_NUMERO_PREAPROBADO=@TCR_NUMERO_PREAPROBADO, SLS_PROBLEMA_EMAIL=@SLS_PROBLEMA_EMAIL,
                                                    SLS_ENVIO_NOTIFICACION=@SLS_ENVIO_NOTIFICACION,  SLS_ESTADO=@SLS_ESTADO,
                                                    SLS_USUARIO_ACTUALIZA=@SLS_USUARIO_ACTUALIZA, SLS_FECHA_ACTUALIZA=@SLS_FECHA_ACTUALIZA
                                                WHERE SLS_ID=@SLS_ID;" + QueryGetById;

    }
}
