/*
Nombre: CrearSolicCreditoInfJurInm
Descripcion: Crea o acualiza los datos Juridicos del Inmueble de la Solicitud de Credito
Elaboro: German Eduardo Guarnizo
Fecha: Abril 30 de 2021
*/
CREATE PROCEDURE[dbo].[CrearSolicCreditoInfJurInm]
@SJI_ID uniqueidentifier,
@SIJ_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@SJI_NUMERO_MATRICULA varchar(20),
@SJI_CEDULA_CATASTRAL varchar(20),
@SJI_AREA_PRIVADA decimal(9, 2),
@SJI_VALOR_AVALUO_COMERCIAL decimal(22, 0),
@SJI_VALOR_AVALUO_CATASTRAL decimal(22, 0),
@SJI_CREADO_POR uniqueidentifier,
@SJI_FECHA_CREACION datetime

AS
BEGIN
Declare @mIdJuridicaInm int
	Select @mIdJuridicaInm = count(*) From SJI_SOLICITUD_INF_JUR_INM 
	 Where SJI_ID = @SJI_ID
	   And SIJ_ID = @SIJ_ID
	   And SOC_ID = @SOC_ID

	If @mIdJuridicaInm = 0
	Begin
		--- Creo los datos del conyugue
		Insert into SJI_SOLICITUD_INF_JUR_INM (SJI_ID, SIJ_ID, SOC_ID, SJI_NUMERO_MATRICULA, SJI_CEDULA_CATASTRAL, SJI_AREA_PRIVADA,
											   SJI_VALOR_AVALUO_COMERCIAL, SJI_VALOR_AVALUO_CATASTRAL,
											   SJI_CREADO_POR, SJI_FECHA_CREACION, SJI_ACTUALIZADO_POR, SJI_FECHA_ACTUALIZA
											)
						
		Values(@SJI_ID, @SIJ_ID, @SOC_ID, @SJI_NUMERO_MATRICULA, @SJI_CEDULA_CATASTRAL, @SJI_AREA_PRIVADA,
				@SJI_VALOR_AVALUO_COMERCIAL, @SJI_VALOR_AVALUO_CATASTRAL,
				@SJI_CREADO_POR, @SJI_FECHA_CREACION, @SJI_CREADO_POR, @SJI_FECHA_CREACION
			)


	End
	Else
	Begin
		Update SJI_SOLICITUD_INF_JUR_INM Set SJI_NUMERO_MATRICULA=@SJI_NUMERO_MATRICULA,
											 SJI_CEDULA_CATASTRAL = @SJI_CEDULA_CATASTRAL,
											 SJI_AREA_PRIVADA = @SJI_AREA_PRIVADA,
											 SJI_VALOR_AVALUO_COMERCIAL = @SJI_VALOR_AVALUO_COMERCIAL,
											 SJI_VALOR_AVALUO_CATASTRAL = @SJI_VALOR_AVALUO_CATASTRAL,
											 SJI_ACTUALIZADO_POR = @SJI_CREADO_POR, SJI_FECHA_ACTUALIZA = @SJI_FECHA_CREACION
	 Where SJI_ID = @SJI_ID
	   And SIJ_ID = @SIJ_ID
	   And SOC_ID = @SOC_ID

	End
	-- Retorno los Datos Juridicos Inmueble
	Select  * From SJI_SOLICITUD_INF_JUR_INM
	 Where SJI_ID = @SJI_ID
	   And SIJ_ID = @SIJ_ID
	   And SOC_ID = @SOC_ID
END
