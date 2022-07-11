/*
Nombre: CrearSolicCreditoInfTecInm
Descripcion: Crea o acualiza los datos Tecnicos del Inmueble de la Solicitud de Credito
Elaboro: German Eduardo Guarnizo
Fecha: Abril 30 de 2021
*/
CREATE PROCEDURE[dbo].[CrearSolicCreditoInfTecInm]
@STI_ID uniqueidentifier,
@SIT_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@STI_NUMERO_MATRICULA varchar(20),
@STI_FECHA_MATRICULA date,
@STI_NUMERO_CHIP varchar(20),
@STI_CEDULA_CATASTRAL varchar(20),
@STI_CREADO_POR uniqueidentifier,
@STI_FECHA_CREACION datetime

AS
BEGIN
Declare @mIdTecnicaInm int
	Select @mIdTecnicaInm = count(*) From STI_SOLICITUD_INF_TEC_INM 
	 Where STI_ID = @STI_ID 
	   And SIT_ID = @SIT_ID
	   And SOC_ID = @SOC_ID

	If @mIdTecnicaInm = 0
	Begin
		--- Creo los datos del conyugue
		Insert into STI_SOLICITUD_INF_TEC_INM (STI_ID, SIT_ID, SOC_ID, STI_NUMERO_MATRICULA, STI_FECHA_MATRICULA,
											   STI_NUMERO_CHIP, STI_CEDULA_CATASTRAL,
											   STI_CREADO_POR, STI_FECHA_CREACION, STI_ACTUALIZADO_POR, STI_FECHA_ACTUALIZA
											)
						
		Values(@STI_ID, @SIT_ID, @SOC_ID, @STI_NUMERO_MATRICULA, @STI_FECHA_MATRICULA,
				@STI_NUMERO_CHIP, @STI_CEDULA_CATASTRAL,
				@STI_CREADO_POR, @STI_FECHA_CREACION, @STI_CREADO_POR, @STI_FECHA_CREACION
			)


	End
	Else
	Begin
		Update STI_SOLICITUD_INF_TEC_INM Set STI_NUMERO_MATRICULA=@STI_NUMERO_MATRICULA,
											 STI_FECHA_MATRICULA = @STI_FECHA_MATRICULA,
											 STI_NUMERO_CHIP = @STI_NUMERO_CHIP,
											 STI_CEDULA_CATASTRAL = @STI_CEDULA_CATASTRAL,
											 STI_ACTUALIZADO_POR = @STI_CREADO_POR, STI_FECHA_ACTUALIZA = @STI_FECHA_CREACION
	 Where STI_ID = @STI_ID 
	   And SIT_ID = @SIT_ID
	   And SOC_ID = @SOC_ID

	End
	-- Retorno los Datos Tecnicos Inmueble
	Select  * From STI_SOLICITUD_INF_TEC_INM
	 Where STI_ID = @STI_ID 
	   And SIT_ID = @SIT_ID
	   And SOC_ID = @SOC_ID
END
