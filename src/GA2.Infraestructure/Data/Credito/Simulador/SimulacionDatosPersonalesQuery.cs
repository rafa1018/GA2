namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Query string Simulacion Datos Personales base Datos
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public static class SimulacionDatosPersonalesQuery
    {
        public const string QueryGetAllSimulacionDatosPersonales = @"SELECT SDP_ID, SLS_ID, FRZ_ID, CTG_ID, GRD_ID, SDP_NUMERO_DOCUMENTO, SDP_NOMBRES_APELLIDOS,
                                                                            SDP_EDAD, SDP_FECHA_AFILIACION, DPD_ID, DPC_ID, SDP_DIRECCION, SDP_TELEFONO_FIJO,
                                                                            SDP_TELEFONO_CELULAR, SDP_E_MAIL, SDP_CUOTAS, SDP_REGIMEN, SDP_VALOR_INMUEBLE,
                                                                            TVV_ID, SDP_USUARIO_ACTUALIZA, SDP_FECHA_ACTUALIZA
                                                                 FROM SDP_SIMULACION_DATOS_PERSONALES;";

        public const string QueryGetById = @"SELECT SDP_ID, SLS_ID, FRZ_ID, CTG_ID, GRD_ID, SDP_NUMERO_DOCUMENTO, SDP_NOMBRES_APELLIDOS,
                                                    SDP_EDAD, SDP_FECHA_AFILIACION, DPD_ID, DPC_ID, SDP_DIRECCION, SDP_TELEFONO_FIJO,
                                                    SDP_TELEFONO_CELULAR, SDP_E_MAIL, SDP_CUOTAS, SDP_REGIMEN, SDP_VALOR_INMUEBLE,
                                                    TVV_ID, SDP_USUARIO_ACTUALIZA, SDP_FECHA_ACTUALIZA
                                               FROM SDP_SIMULACION_DATOS_PERSONALES
                                              WHERE SDP_ID=@SDP_ID;";

        public const string QueryGetByNumeroDocumento = @"SELECT SDP_ID, SLS_ID, FRZ_ID, CTG_ID, GRD_ID, SDP_NUMERO_DOCUMENTO, SDP_NOMBRES_APELLIDOS,
                                                    SDP_EDAD, SDP_FECHA_AFILIACION, DPD_ID, DPC_ID, SDP_DIRECCION, SDP_TELEFONO_FIJO,
                                                    SDP_TELEFONO_CELULAR, SDP_E_MAIL, SDP_CUOTAS, SDP_REGIMEN, SDP_VALOR_INMUEBLE,
                                                    TVV_ID, SDP_USUARIO_ACTUALIZA, SDP_FECHA_ACTUALIZA
                                               FROM SDP_SIMULACION_DATOS_PERSONALES
                                              WHERE SDP_NUMERO_DOCUMENTO=@SDP_NUMERO_DOCUMENTO;";

        public const string QueryInsertSimulacionDatosPersonales = @"Insert into SDP_SIMULACION_DATOS_PERSONALES
                                                 (SDP_ID, SLS_ID, FRZ_ID, CTG_ID, GRD_ID, SDP_NUMERO_DOCUMENTO, SDP_NOMBRES_APELLIDOS,
                                                  SDP_EDAD, SDP_FECHA_AFILIACION, DPD_ID, DPC_ID, SDP_DIRECCION, SDP_TELEFONO_FIJO,
                                                  SDP_TELEFONO_CELULAR, SDP_E_MAIL, SDP_CUOTAS, SDP_REGIMEN, SDP_VALOR_INMUEBLE,
                                                  TVV_ID, SDP_USUARIO_ACTUALIZA, SDP_FECHA_ACTUALIZA)
                                        VALUES(@SDP_ID, @SLS_ID, @FRZ_ID, @CTG_ID, @GRD_ID, @SDP_NUMERO_DOCUMENTO, @SDP_NOMBRES_APELLIDOS,
                                               @SDP_EDAD, @SDP_FECHA_AFILIACION, @DPD_ID, @DPC_ID, @SDP_DIRECCION, @SDP_TELEFONO_FIJO,
                                               @SDP_TELEFONO_CELULAR, @SDP_E_MAIL, @SDP_CUOTAS, @SDP_REGIMEN, @SDP_VALOR_INMUEBLE,
                                               @TVV_ID, @SDP_USUARIO_ACTUALIZA, @SDP_FECHA_ACTUALIZA);" + QueryGetById;


        public const string QueryUpdateSimulacionDatosPersonales = @"UPDATE SDP_SIMULACION_DATOS_PERSONALES
                                                SET SDP_DIRECCION=@TSDP_DIRECCION, SDP_TELEFONO_FIJO=@SDP_TELEFONO_FIJO,
                                                    SDP_TELEFONO_CELULAR=@SDP_TELEFONO_CELULAR, SDP_E_MAIL=@SDP_E_MAIL,
                                                    SDP_USUARIO_ACTUALIZA=@SDP_USUARIO_ACTUALIZA, SDP_FECHA_ACTUALIZA=@SDP_FECHA_ACTUALIZA
                                                WHERE SDP_ID=@SDP_ID;" + QueryGetById;

    }
}
