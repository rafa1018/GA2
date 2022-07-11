USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizaSolicCreditoSeguro]    Script Date: 6/07/2021 4:57:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ActualizaSolicCreditoSeguro
Descripcion:  Acualiza los datos de seguro de la solicitud de credito
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 14 de 2021
*/
ALTER PROCEDURE [dbo].[ActualizaSolicCreditoSeguro] 
@SOC_ID uniqueidentifier,
@SOC_CONVENIO_ASEGURADORA varchar(1),
@SOC_CONVENIO_ASEGURADORA_HOGAR varchar(1),
@ASE_ID int,
@SOC_PORC_EXTRAPRIMA decimal(5,2),
@SOC_ACTUALIZADO_POR uniqueidentifier,
@SOC_FECHA_ACTUALIZA datetime

AS
BEGIN
		Update SOC_SOLICITUD_CREDITO Set SOC_CONVENIO_ASEGURADORA=@SOC_CONVENIO_ASEGURADORA,
										 SOC_CONVENIO_ASEGURADORA_HOGAR=@SOC_CONVENIO_ASEGURADORA_HOGAR,
										 ASE_ID=@ASE_ID,
										 SOC_PORC_EXTRAPRIMA=@SOC_PORC_EXTRAPRIMA,
									     SOC_ACTUALIZADO_POR = @SOC_ACTUALIZADO_POR, 
										 SOC_FECHA_ACTUALIZA = @SOC_FECHA_ACTUALIZA

        Where SOC_ID = @SOC_ID

		IF @SOC_PORC_EXTRAPRIMA != 0
		Begin
			Update SLS_SOLICITUD_SIMULACION SET SLS_PORC_EXTRAPRIMA = @SOC_PORC_EXTRAPRIMA
			       From SOC_SOLICITUD_CREDITO SOC
			Where SLS_SOLICITUD_SIMULACION.SLS_ID = SOC.SLS_ID
		End
	-- Retorno los Datos SOlicitud Credito
	Select  * From SOC_SOLICITUD_CREDITO
	 Where SOC_ID = @SOC_ID
END
