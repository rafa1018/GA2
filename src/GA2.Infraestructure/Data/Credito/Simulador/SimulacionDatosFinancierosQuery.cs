namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Query string Simulacion Datos Financieros base Datos
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public static class SimulacionDatosFinancierosQuery
    {
        public const string QueryGetAllSimulacionDatosFinancieros = @"SELECT SDF_ID, SLS_ID, SDF_DESCRIPCION_SALARIO, SDF_VALOR_SALARIO, SDF_DESCRIPCION_OTRO_INGRESOS,
                                                                             SDF_VALOR_OTROS_INGRESOS, SDF_DESCRIPCION_OTRO_ING1, SDF_VALOR_OTROS_INGRESOS1,
                                                                             SDF_DESCRIPCION_OTRO_ING2, SDF_VALOR_OTROS_INGRESOS2, SDF_DESCRIPCION_OTRO_ING3, SDF_VALOR_OTROS_INGRESOS3,
                                                                             SDF_DESCRIPCION_OTRO_ING4, SDF_VALOR_OTROS_INGRESOS4, SDF_DESCRIPCION_OTRO_ING5, SDF_VALOR_OTROS_INGRESOS5,
                                                                             SDF_VALOR_TOTAL_INGRESOS, SDF_VALOR_TOTAL_EGRESOS, SDF_USUARIO_ACTUALIZA, SDF_FECHA_ACTUALIZA
                                                                 FROM SDF_SIMULACION_DATOS_FINANCIEROS;";

        public const string QueryGetById = @"SELECT SDF_ID, SLS_ID, SDF_DESCRIPCION_SALARIO, SDF_VALOR_SALARIO, SDF_DESCRIPCION_OTRO_INGRESOS,
                                                    SDF_VALOR_OTROS_INGRESOS, SDF_DESCRIPCION_OTRO_ING1, SDF_VALOR_OTROS_INGRESOS1,
                                                    SDF_DESCRIPCION_OTRO_ING2, SDF_VALOR_OTROS_INGRESOS2, SDF_DESCRIPCION_OTRO_ING3, SDF_VALOR_OTROS_INGRESOS3,
                                                    SDF_DESCRIPCION_OTRO_ING4, SDF_VALOR_OTROS_INGRESOS4, SDF_DESCRIPCION_OTRO_ING5, SDF_VALOR_OTROS_INGRESOS5,
                                                    SDF_VALOR_TOTAL_INGRESOS, SDF_VALOR_TOTAL_EGRESOS, SDF_USUARIO_ACTUALIZA, SDF_FECHA_ACTUALIZA
                                               FROM SDF_SIMULACION_DATOS_FINANCIEROS
                                              WHERE SDF_ID=@SDF_ID;";

        public const string QueryGetByIdSimulacion = @"SELECT SDF_ID, SLS_ID, SDF_DESCRIPCION_SALARIO, SDF_VALOR_SALARIO, SDF_DESCRIPCION_OTRO_INGRESOS,
                                                    SDF_VALOR_OTROS_INGRESOS, SDF_DESCRIPCION_OTRO_ING1, SDF_VALOR_OTROS_INGRESOS1,
                                                    SDF_DESCRIPCION_OTRO_ING2, SDF_VALOR_OTROS_INGRESOS2, SDF_DESCRIPCION_OTRO_ING3, SDF_VALOR_OTROS_INGRESOS3,
                                                    SDF_DESCRIPCION_OTRO_ING4, SDF_VALOR_OTROS_INGRESOS4, SDF_DESCRIPCION_OTRO_ING5, SDF_VALOR_OTROS_INGRESOS5,
                                                    SDF_VALOR_TOTAL_INGRESOS, SDF_VALOR_TOTAL_EGRESOS, SDF_USUARIO_ACTUALIZA, SDF_FECHA_ACTUALIZA
                                               FROM SDF_SIMULACION_DATOS_FINANCIEROS
                                              WHERE SLS_ID=@SLS_ID;";

        public const string QueryInsertSimulacionDatosFinancieros = @"Insert into SDF_SIMULACION_DATOS_FINANCIEROS
                                                 (SDF_ID, SLS_ID, SDF_DESCRIPCION_SALARIO, SDF_VALOR_SALARIO, SDF_DESCRIPCION_OTRO_INGRESOS,
                                                  SDF_VALOR_OTROS_INGRESOS, SDF_DESCRIPCION_OTRO_ING1, SDF_VALOR_OTROS_INGRESOS1,
                                                  SDF_DESCRIPCION_OTRO_ING2, SDF_VALOR_OTROS_INGRESOS2, SDF_DESCRIPCION_OTRO_ING3, SDF_VALOR_OTROS_INGRESOS3,
                                                  SDF_DESCRIPCION_OTRO_ING4, SDF_VALOR_OTROS_INGRESOS4, SDF_DESCRIPCION_OTRO_ING5, SDF_VALOR_OTROS_INGRESOS5,
                                                  SDF_VALOR_TOTAL_INGRESOS, SDF_VALOR_TOTAL_EGRESOS, SDF_USUARIO_ACTUALIZA, SDF_FECHA_ACTUALIZA)
                                        VALUES(@SDF_ID, @SLS_ID, @SDF_DESCRIPCION_SALARIO, @SDF_VALOR_SALARIO, @SDF_DESCRIPCION_OTRO_INGRESOS,
                                               @SDF_VALOR_OTROS_INGRESOS, @SDF_DESCRIPCION_OTRO_ING1, @SDF_VALOR_OTROS_INGRESOS1,
                                               @SDF_DESCRIPCION_OTRO_ING2, @SDF_VALOR_OTROS_INGRESOS2, @SDF_DESCRIPCION_OTRO_ING3, @SDF_VALOR_OTROS_INGRESOS3,
                                               @SDF_DESCRIPCION_OTRO_ING4, @SDF_VALOR_OTROS_INGRESOS4, @SDF_DESCRIPCION_OTRO_ING5, @SDF_VALOR_OTROS_INGRESOS5,
                                               @SDF_VALOR_TOTAL_INGRESOS, @SDF_VALOR_TOTAL_EGRESOS, @SDF_USUARIO_ACTUALIZA, @SDF_FECHA_ACTUALIZA);" + QueryGetByIdSimulacion;


        public const string QueryUpdateSimulacionDatosFinancieros = @"UPDATE SDF_SIMULACION_DATOS_FINANCIEROS
                                                SET SDF_VALOR_SALARIO=@SDF_VALOR_SALARIO, SDF_DESCRIPCION_OTRO_INGRESOS=@SDF_DESCRIPCION_OTRO_INGRESOS,
                                                    SDF_VALOR_OTROS_INGRESOS=@SDF_VALOR_OTROS_INGRESOS, SDF_DESCRIPCION_OTRO_ING1=@SDF_DESCRIPCION_OTRO_ING1,
                                                    SDF_VALOR_OTROS_INGRESOS1=@SDF_VALOR_OTROS_INGRESOS1, SDF_DESCRIPCION_OTRO_ING2=@SDF_DESCRIPCION_OTRO_ING2,
                                                    SDF_VALOR_OTROS_INGRESOS2=@SDF_VALOR_OTROS_INGRESOS2, SDF_DESCRIPCION_OTRO_ING3=@SDF_DESCRIPCION_OTRO_ING3,
                                                    SDF_VALOR_OTROS_INGRESOS3=@SDF_VALOR_OTROS_INGRESOS3, SDF_DESCRIPCION_OTRO_ING4=@SDF_DESCRIPCION_OTRO_ING4, 
                                                    SDF_VALOR_OTROS_INGRESOS4=@SDF_VALOR_OTROS_INGRESOS4, SDF_DESCRIPCION_OTRO_ING5=@SDF_DESCRIPCION_OTRO_ING5,
                                                    SDF_VALOR_OTROS_INGRESOS5=@SDF_VALOR_OTROS_INGRESOS5, SDF_VALOR_TOTAL_INGRESOS=@SDF_VALOR_TOTAL_INGRESOS, 
                                                    SDF_VALOR_TOTAL_EGRESOS=@SDF_VALOR_TOTAL_EGRESOS, SDF_USUARIO_ACTUALIZA=@SDF_USUARIO_ACTUALIZA, SDF_FECHA_ACTUALIZA=@SDF_FECHA_ACTUALIZA
                                                WHERE SLS_ID=@SLS_ID;" + QueryGetByIdSimulacion;

    }
}
