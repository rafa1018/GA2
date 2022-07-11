/*
Nombre: ObtenerClientePorTipoIdentificationYNumero
Descripcion: Obteniene cliente por tipo y numero de identificacion
Elaboro: Edgar Andrés Riaño Suárez
Fecha: Mayo 7 de 2021
*/

ALTER PROC [dbo].[ObtenerClientePorTipoIdentificationYNumero] (
	@IdTipoIdentificacion int,
	@Identificacion varchar(20)
)
AS
BEGIN
	SELECT	 CC.CLI_ID
			,CC.TPA_ID
			,CC.TID_ID
			,CC.CLI_IDENTIFICACION
			,CC.CLI_FECHA_EXPEDICION
			,CC.DPD_ID_IDENTIFICACION_EXPEDIDA
			,CC.DPC_ID_IDENTIFICACION_EXPEDIDA
			,CC.CLI_LUGAR_EXPEDICION
			,CC.CLI_CODIGO_MILITAR
			,CC.CLI_PRIMER_NOMBRE
			,CC.CLI_SEGUNDO_NOMBRE
			,CC.CLI_PRIMER_APELLIDO
			,CC.CLI_SEGUNDO_APELLIDO
			,CC.CLI_FECHA_NACIMIENTO
			,CC.DPP_ID_PAIS_NACIMIENTO
			,CC.DPD_ID
			,CC.DPC_ID
			,CC.CLI_LUGAR_NACIMIENTO
			,CC.CAT_SEXO
			,CC.CAT_ESTADO_CIVIL
			,CC.CLI_PROFESION
			,CC.CLI_UNIDAD
			,CC.CTG_ID
			,CC.FRZ_ID
			,CC.GRD_ID
			,CC.UEJ_ID	
			,CC.CLI_FECHA_INSCRIPCION
			,CC.CLI_FECHA_ALTA
			,CC.CLI_REGIMEN
			,CC.CTS_SLP
			,CC.CLI_FECHA_REINTEGRO
			,CC.ECL_ID
			,CC.CLI_VALIDACION
			,CC.CLI_ID_PATROCINADOR
			,CC.CLI_PARTICIPACION
			,CC.CLI_RESOLUCION
			,CC.CLI_VALIDACION_BIOMETRICA
			,CC.ECL_ID_AVAL
			,CCIE.CIE_ID
			,CCIE.CLI_ID
			,CCIE.ACC_ID
			,CCIE.CIE_FECHA_INFO_ECONOMICA
			,CCIE.CIE_INGRESO_MENSUAL
			,CCIE.CIE_EGRESO_MENSUAL
			,CCIE.CIE_TOTAL_ACTIVOS
			,CCIE.CIE_TOTAL_PASIVOS
			,CCIE.CIE_TOTAL_PATRIMONIO
			,CCIE.CIE_INGRESO_ADICIONAL
			,CCIE.CIE_CONCEPTO_INGRESO_ADICIONAL
			,CCIE.CIE_TRANS_EXTRANJERO
			,CCIE.MND_ID
			,CCIE.CIE_VALOR_TRANSFERENCIA
			,DRC.DRC_ID
			,DRC.CLI_ID
			,DRC.DRC_CONSECUTIVO
			,DRC.DPP_ID_RESIDENCIA
			,DRC.DPD_ID_RESIDENCIA
			,DRC.DPC_ID_RESIDENCIA
			,DRC.DRC_CIUDAD_RESIDENCIA_EXTRANJERO
			,DRC.TPC_TIPO_CALLE
			,DRC.DRC_NUMERO_1
			,DRC.LTR_LETRA_1
			,DRC.BS_BIS_1
			,DRC.CRD_CARDINAL_1
			,DRC.DRC_NUMERO_2
			,DRC.LTR_LETRA_2
			,DRC.BS_BIS_2
			,DRC.CRD_CARDINAL_2
			,DRC.DRC_NUMERO_3
			,DRC.LTR_LETRA_3
			,DRC.CRD_CARDINAL_3
			,DRC.DRC_COMPLEMENTO_DIRECCION
			,DRC.DRC_DIRECCION
			,DRC.DRC_BARRIO
			,DRC.TPD_ID
			,DRC.ID_SISTEMA_SIS
			,DRCC.DCE_ID
			,DRCC.DRC_ID
			,DRCC.DCE_CORREO
			,DRCC.TCE_ID
			,DRCC.DCE_ENVIO_INFORMACION
			,DRCC.DCE_ACTIVO
			,DRCT.DTL_ID
			,DRCT.DRC_ID
			,DRCT.DTL_INDICATIVO_PAIS
			,DRCT.DTL_INDICATIVO_CIUDAD
			,DRCT.DTL_TELEFONO
			,DRCT.TPT_ID
			,DRCT.DTL_ENVIO_INFORMACION
			,DRCT.DTL_ACTIVO
			,CNY.CNY_ID
			,CNY.CNY_TID_ID
			,CNY.CNY_IDENTIFICACION
			,CNY.CNY_PRIMER_NOMBRE
			,CNY.CNY_SEGUNDO_NOMBRE
			,CNY.CNY_PRIMER_APELLIDO
			,CNY.CNY_SEGUNDO_APELLIDO
			,CNY.CNY_ACTIVO
	from CLI_CLIENTE CC
	INNER JOIN DRC_DIRECCION_CLIENTE DRC 
	ON CC.CLI_ID = DRC.CLI_ID
	INNER JOIN DRC_DIRECCION_CORREO DRCC
	ON DRC.DRC_ID = DRCC.DRC_ID
	INNER JOIN DRC_DIRECCION_TELEFONO DRCT
	ON DRC.DRC_ID = DRCT.DRC_ID
	INNER JOIN CLI_CLIENTE_INFO_ECONOMICA CCIE 
	ON CC.CLI_ID = CCIE.CLI_ID
	LEFT JOIN CNY_CONYUGE_CLIENTE CNY
	ON CNY.CLI_ID = CC.CLI_ID
	where CC.TID_ID = @IdTipoIdentificacion 
		AND CC.CLI_IDENTIFICACION = @Identificacion
		--AND CC.CLI_ACTIVO = 1
END

GO



