USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizaSolicCreditoTasas]    Script Date: 6/07/2021 4:53:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ActualizaSolicCreditoTasas
Descripcion:  Acualiza los datos de tasa frech y alivio en legalizacion
Elaboro: German Eduardo Guarnizo
Fecha: Junio 11 de 2021
*/
ALTER PROCEDURE [dbo].[ActualizaSolicCreditoTasas] 
@SOC_ID uniqueidentifier,
@SOC_TASA_FRECH decimal(5,2),
@SOC_VALOR_ALIVIO decimal(22,2),
@SOC_ACTUALIZADO_POR uniqueidentifier,
@SOC_FECHA_ACTUALIZA datetime

AS
BEGIN
		Update SOC_SOLICITUD_CREDITO Set SOC_TASA_FECH = @SOC_TASA_FRECH,
																	      SOC_VALOR_ALIVIO = @SOC_VALOR_ALIVIO,
									     SOC_ACTUALIZADO_POR = @SOC_ACTUALIZADO_POR, 
										 SOC_FECHA_ACTUALIZA = @SOC_FECHA_ACTUALIZA

        Where SOC_ID = @SOC_ID

	-- Retorno los Datos SOlicitud Credito
	Select  * From SOC_SOLICITUD_CREDITO
	 Where SOC_ID = @SOC_ID
END
