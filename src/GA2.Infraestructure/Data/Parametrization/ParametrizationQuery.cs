namespace GA2.Infraestructure.Data.Parametrization
{
    public class ParametrizationQuery
    {
        public const string GetLastInsurance = @"SELECT SEG_ID,SEG_VIDA,SEG_TODO_RIESGO,SEG_FECHA_MODIFICACION,SEG_MODIFICADO_POR,SEG_ESTADO
											FROM GA2..PARAM_SEGURO
											WHERE SEG_FECHA_MODIFICACION =
													(SELECT MAX(SEG_FECHA_MODIFICACION) FROM GA2..PARAM_SEGURO WHERE SEG_ESTADO = 1)";

        public const string InsertInsurance = @"INSERT INTO GA2..PARAM_SEGURO(SEG_VIDA, SEG_TODO_RIESGO,SEG_FECHA_MODIFICACION,SEG_MODIFICADO_POR,SEG_ESTADO) 
                                                VALUES (@VIDA, @TODO_RIESGO,@FECHAMODIFICACION,@MODIFICADOPOR,@ESTADO)" + " " + GetLastInsurance;

        public const string UpdateInsurance = @"UPDATE GA2..PARAM_SEGURO 
                                                SET SEG_ESTADO = 0
                                                WHERE SEG_ID = @ID";

        public const string GetLastRate = @"SELECT TAS_ID,TAS_USURA_EA,TAS_USURA_NM,TAS_CORRIENTE_EA,TAS_CORRIENTE_NM,TAS_FECHA_MODIFICACION,TAS_MODIFICADO_POR,TAS_ESTADO
											FROM GA2..PARAM_TASA
											WHERE TAS_FECHA_MODIFICACION =
													(SELECT MAX(TAS_FECHA_MODIFICACION) FROM GA2..PARAM_TASA WHERE TAS_ESTADO = 1)";

        public const string InsertRate = @"INSERT INTO GA2..PARAM_TASA(TAS_USURA_EA,TAS_USURA_NM,TAS_CORRIENTE_EA,TAS_CORRIENTE_NM,TAS_FECHA_MODIFICACION,TAS_MODIFICADO_POR,TAS_ESTADO) 
                                                VALUES (@TASAUSURAEA, @TASAUSURANM,@TASACORRIENTEEA, @TASACORRIENTENM,@FECHAMODIFICACION,@MODIFICADOPOR,@ESTADO)" + " " + GetLastRate;

        public const string UpdateRate = @"UPDATE GA2..PARAM_TASA 
                                                SET TAS_ESTADO = 0
                                                WHERE TAS_ID = @ID";

        public const string GetLastDeadline = @"SELECT PLAZ_ID,PLAZ_YEAR_MIN,PLAZ_MONTH_MIN,PLAZ_YEAR_MAX,PLAZ_MONTH_MAX,PLAZ_FECHA_MODIFICACION,PLAZ_MODIFICADO_POR,PLAZ_ESTADO
											FROM GA2..PARAM_PLAZOS
											WHERE PLAZ_FECHA_MODIFICACION =
													(SELECT MAX(PLAZ_FECHA_MODIFICACION) FROM GA2..PARAM_PLAZOS WHERE PLAZ_ESTADO = 1)";

        public const string InsertDeadline = @"INSERT INTO GA2..PARAM_PLAZOS(PLAZ_YEAR_MIN,PLAZ_MONTH_MIN,PLAZ_YEAR_MAX,PLAZ_MONTH_MAX,PLAZ_FECHA_MODIFICACION,PLAZ_MODIFICADO_POR,PLAZ_ESTADO) 
                                                VALUES (@YEARMIN, @MONTHMIN,@YEARMAX, @MONTHMAX,@FECHAMODIFICACION,@MODIFICADOPOR,@ESTADO)" + " " + GetLastDeadline;

        public const string UpdateDeadline = @"UPDATE GA2..PARAM_PLAZOS 
                                                SET PLAZ_ESTADO = 0
                                                WHERE PLAZ_ID = @ID";

        public const string GetLastLegalTasa = @"SELECT LEG_T_ID,LEG_T_TASA_FRECH,LEG_T_VIGENCIA_TASA_FRECH,LEG_T_FECHA_MODIFICACION,LEG_T_MODIFICADO_POR,LEG_T_ESTADO
											    FROM GA2..PARAM_LEGAL_TASA
											    WHERE LEG_T_FECHA_MODIFICACION =
												(SELECT MAX(LEG_T_FECHA_MODIFICACION) FROM GA2..PARAM_LEGAL_TASA WHERE LEG_T_ESTADO = 1)";

        public const string InsertLegalTasa = @"INSERT INTO GA2..PARAM_LEGAL_TASA(LEG_T_TASA_FRECH,LEG_T_VIGENCIA_TASA_FRECH,LEG_T_FECHA_MODIFICACION,LEG_T_MODIFICADO_POR,LEG_T_ESTADO) 
                                                VALUES (@TASAFRECH, @VIGENCIATASAFRECH,@FECHAMODIFICACION,@MODIFICADOPOR,@ESTADO)" + " " + GetLastLegalTasa;

        public const string UpdateLegalTasa = @"UPDATE GA2..PARAM_LEGAL_TASA 
                                                SET LEG_T_ESTADO = 0
                                                WHERE LEG_T_ID = @ID";

        public const string GetLastLegalAlivio = @"SELECT LEG_A_ID,LEG_A_ALIVIO_CUOTA,LEG_A_VIGENCIA_ALIVIO_CUOTA,LEG_A_FECHA_MODIFICACION,LEG_A_MODIFICADO_POR,LEG_A_ESTADO
                                                FROM GA2..PARAM_LEGAL_ALIVIO
                                                WHERE LEG_A_FECHA_MODIFICACION =
                                                (SELECT MAX(LEG_A_FECHA_MODIFICACION) FROM GA2..PARAM_LEGAL_ALIVIO WHERE LEG_A_ESTADO = 1)";

        public const string InsertLegalAlivio = @"INSERT INTO GA2..PARAM_LEGAL_ALIVIO(LEG_A_ALIVIO_CUOTA,LEG_A_VIGENCIA_ALIVIO_CUOTA,LEG_A_FECHA_MODIFICACION,LEG_A_MODIFICADO_POR,LEG_A_ESTADO) 
                                                VALUES (@ALIVIOCUOTA, @VIGENCIAALIVIOCUOTA,@FECHAMODIFICACION,@MODIFICADOPOR,@ESTADO)" + " " + GetLastLegalAlivio;

        public const string UpdateLegalAlivio = @"UPDATE GA2..PARAM_LEGAL_ALIVIO 
                                                SET LEG_A_ESTADO = 0
                                                WHERE LEG_A_ID = @ID";

        public const string GetLastLegalGmf = @"SELECT LEG_G_ID,LEG_G_GMF,LEG_G_VIGENCIA_GMF,LEG_G_FECHA_MODIFICACION,LEG_G_MODIFICADO_POR,LEG_G_ESTADO
                                                FROM GA2..PARAM_LEGAL_GMF
                                                WHERE LEG_G_FECHA_MODIFICACION =
                                                (SELECT MAX(LEG_G_FECHA_MODIFICACION) FROM GA2..PARAM_LEGAL_GMF WHERE LEG_G_ESTADO = 1)";

        public const string InsertLegalGmf = @"INSERT INTO GA2..PARAM_LEGAL_GMF(LEG_G_GMF,LEG_G_VIGENCIA_GMF,LEG_G_FECHA_MODIFICACION,LEG_G_MODIFICADO_POR,LEG_G_ESTADO) 
                                                VALUES (@GMF, @VIGENCIAGMF,@FECHAMODIFICACION,@MODIFICADOPOR,@ESTADO)" + " " + GetLastLegalGmf;

        public const string UpdateLegalGmf = @"UPDATE GA2..PARAM_LEGAL_GMF 
                                                SET LEG_G_ESTADO = 0
                                                WHERE LEG_G_ID = @ID";

        public const string GetLastSettlement = @"SELECT LIQ_ID,LIQ_FECHA_CORTE,LIQ_FECHA_PAGO,LIQ_FECHA_MODIFICACION,LIQ_MODIFICADO_POR,LIQ_ESTADO
											    FROM GA2..PARAM_LIQUIDACION
											    WHERE LIQ_FECHA_MODIFICACION =
												(SELECT MAX(LIQ_FECHA_MODIFICACION) FROM GA2..PARAM_LIQUIDACION WHERE LIQ_ESTADO = 1)";

        public const string InsertSettlement = @"INSERT INTO GA2..PARAM_LIQUIDACION(LIQ_FECHA_CORTE,LIQ_FECHA_PAGO,LIQ_FECHA_MODIFICACION,LIQ_MODIFICADO_POR,LIQ_ESTADO) 
                                                VALUES (@FECHACORTE,@FECHAPAGO,@FECHAMODIFICACION,@MODIFICADOPOR,@ESTADO)" + " " + GetLastSettlement;

        public const string UpdateSettlement = @"UPDATE GA2..PARAM_LIQUIDACION 
                                                SET LIQ_ESTADO = 0
                                                WHERE LIQ_ID = @ID";
    }
}
