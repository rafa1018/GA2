namespace GA2.Transversals.Commons
{
    public class ClientConstants
    {
        public const string QueryUpdate = @"UPDATE CIE_CLIENTE SET 
                                            TID_ID = @Tipo_Id,
                                            CLI_IDENTIFICACION = @Identificacion,
                                            DPC_ID_IDENTIFICACION_EXPEDIDA = @LugarExpedicionId,
                                            CLI_FECHA_EXPEDICION = @FechaExpedicionId,
                                            CLI_PRIMER_NOMBRE = @PrimerNombre,
                                            CLI_SEGUNDO_NOMBRE = @SegundoNombre,
                                            CLI_PRIMER_APELLIDO = @PrimerApellido,
                                            CLI_SEGUNDO_APELLIDO = @SegundoApellido,
                                            CLI_ENVIAR_INFORMACION = @EnvioInformacion,
                                            CAT_SEXO = @Sexo,
                                            CAT_ESTADO_CIVIL = @EstadoCivil,
                                            DPC_ID = @CiudadNacimiento,
                                            CLI_FECHA_ADQUISION_VIVIENDA = @FechaAdquisionVivienda,
                                            CLI_PROFESION = @Profesion,
                                            CLI_ACTIVIDAD = @Actividad,
                                            TVV_ID = @TipoViviendaPosee,
                                            TID_ID_CNY = @TipoIdConyuge,
                                            CLI_CNY_IDENTIFICACION = @IdConyuge,
                                            CLI_CNY_PRIMER_NOMBRE = @PrimerNombreConyuge,
                                            CLI_CNY_SEGUNDO_NOMBRE = @SegundoNombreConyuge,
                                            CLI_CNY_PRIMER_APELLIDO = @PrimerApellidoConyuge,
                                            CLI_CNY_SEGUNDO_APELLIDO = @SegundoApellidoConyuge,
                                            CLI_FECHA_NACIMIENTO = @FechaNacimiento                                          
                                                                                       

                                            WHERE CLI_ID=@Id ";


        public const string ObtenerLoginPaa = @"SELECT CLI_ID, CLI_CODIGO_MILITAR, TPA_ID, TID_ID, CLI_IDENTIFICACION, 
                                             DPC_ID_IDENTIFICACION_EXPEDIDA, CLI_FECHA_EXPEDICION, CLI_PRIMER_NOMBRE, 
                                             CLI_SEGUNDO_NOMBRE, CLI_PRIMER_APELLIDO, CLI_SEGUNDO_APELLIDO, ECL_ID, GRD_ID, 
                                            CLI_FECHA_INSCRIPCION, CLI_UNIDAD, CLI_FECHA_ALTA, CLI_ENVIAR_INFORMACION, CTS_SLP, 
                                            CLI_ID_PATROCINADOR, CLI_PARTICIPACION, CAT_SEXO, CAT_ESTADO_CIVIL, DPC_ID, 
                                            CLI_FECHA_ADQUISION_VIVIENDA, CLI_PROFESION, CLI_ACTIVIDAD, CLI_INGRESOS_MENSUALES, 
                                            CLI_EGRESOS_MENSUALES, CLI_TOTAL_ACTIVOS, CLI_TOTAL_PASIVOS, CLI_INGRESOS_ADICIONALES, 
                                            CLI_CONCEPTO_ADICIONALES, CLI_FECHA_ACTUALIZACION_DATOS, UEJ_ID, TVV_ID, CLI_REGIMEN, 
                                            CLI_DERECHO_ADQUIRIDO, CLI_TASA_APORTE, CLI_TASA_VOLUNTARIA, CLI_VALIDACION, CLI_FECHA_NACIMIENTO, 
                                            FRZ_ID, CLI_VALOR_TRANSFERENCIAS, CLI_RESOLUCION, CLI_TASA_SALARIO_BASE, CVF_ID, GVF_ID, GSF_ID, 
                                            CLI_MODELO_SUBSIDIO, CLI_PARTICIPACION_SUBSIDIO, ECL_ID_AVAL FROM BUA.dbo.CIE_CLIENTE WHERE
                                            TID_ID=@TID_ID AND CLI_IDENTIFICACION=@CLI_IDENTIFICACION  AND CLI_FECHA_EXPEDICION=@CLI_FECHA_EXPEDICION
                                
;
";


    }
}
