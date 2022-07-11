IF OBJECT_ID('ObtenerInformacionClienteCedula') IS NOT NULL
BEGIN
	DROP PROCEDURE ObtenerInformacionClienteCedula
END
GO
/*
Nombre: ObtenerInformacionClienteCedula
Descripcion: Consultar usuario por documento 
Elaboro: Erwin Pantoja España
Fecha: Octubre 04 de 2021
*/
CREATE PROCEDURE ObtenerInformacionClienteCedula(
	@Identificacion varchar(20)
)
AS
BEGIN
		SELECT	 CC.CLI_ID
			,CC.TPA_ID
			,CC.TID_ID
			,CC.DPC_ID_IDENTIFICACION_EXPEDIDA
			,CC.DPD_ID_IDENTIFICACION_EXPEDIDA
			,CC.CLI_IDENTIFICACION
			,CC.CLI_FECHA_EXPEDICION
			,CC.CLI_PRIMER_NOMBRE
			,CC.CLI_SEGUNDO_NOMBRE
			,CC.CLI_PRIMER_APELLIDO
			,CC.CLI_SEGUNDO_APELLIDO
			,CC.CLI_FECHA_NACIMIENTO
			,CC.DPD_ID
			,CC.DPC_ID
			,CC.CAT_SEXO
			,CC.CAT_ESTADO_CIVIL
			,CC.CAT_ESTADO_CIVIL
			,CC.CLI_PROFESION
			,CC.CLI_UNIDAD
			,CC.CTG_ID
			,CC.FRZ_ID
			,CC.GRD_ID
	from CLI_CLIENTE CC
	where CC.CLI_IDENTIFICACION = @Identificacion
END
