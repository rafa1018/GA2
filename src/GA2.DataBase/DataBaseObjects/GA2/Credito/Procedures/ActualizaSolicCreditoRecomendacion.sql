USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizaSolicCreditoRecomendacion]    Script Date: 6/07/2021 4:56:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ActualizaSolicCreditoRecomendacion
Descripcion:  Acualiza los datos derecomendacion analisis financiero
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 14 de 2021
*/
ALTER PROCEDURE [dbo].[ActualizaSolicCreditoRecomendacion] 
@SOC_ID uniqueidentifier,
@SOC_VALOR_RECOMENDADO_CREDITO decimal(22,6),
@SOC_OBSERVACION_RECOMENDACION varchar(500),
@SOC_TIPO_ALIVIO varchar(20)='',
@SOC_ACTUALIZADO_POR uniqueidentifier,
@SOC_FECHA_ACTUALIZA datetime

AS
BEGIN
		Update SOC_SOLICITUD_CREDITO Set SOC_VALOR_RECOMENDADO_CREDITO=@SOC_VALOR_RECOMENDADO_CREDITO,
										 SOC_OBSERVACION_RECOMENDACION=@SOC_OBSERVACION_RECOMENDACION,
										 SOC_TIPO_ALIVIO = @SOC_TIPO_ALIVIO,
									     SOC_ACTUALIZADO_POR = @SOC_ACTUALIZADO_POR, 
										 SOC_FECHA_ACTUALIZA = @SOC_FECHA_ACTUALIZA

        Where SOC_ID = @SOC_ID

	-- Retorno los Datos SOlicitud Credito
	Select  * From SOC_SOLICITUD_CREDITO
	 Where SOC_ID = @SOC_ID
END
