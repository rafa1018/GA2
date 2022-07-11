USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearSolicCreditoDesembolsos]    Script Date: 6/07/2021 4:46:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: CrearSolicCreditoDesembolsos
Descripcion: Crea o acualiza los datos de los desembolsos en el panel de desembolsos
Elaboro: German Eduardo Guarnizo
Fecha: Junio 11 de 2021
*/
ALTER PROCEDURE [dbo].[CrearSolicCreditoDesembolsos] 
@SID_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@FRC_ID int,
@SID_VALOR_DESEMBOLSO decimal(22,2),
@SID_FECHA_DESEMBOLSO date,
@SID_CREADO_POR uniqueidentifier,
@SID_FECHA_CREACION datetime

AS
BEGIN
Declare @mIdDesem int
	Select @mIdDesem = count(*) From SID_SOLICITUD_INF_DESEMBOLSO 
	 Where SID_ID = @SID_ID
	   And SOC_ID = @SOC_ID

	If @mIdDesem = 0
	Begin
		--- Creo los datos del conyugue
		Insert into SID_SOLICITUD_INF_DESEMBOLSO (SID_ID,SOC_ID,FRC_ID,SID_VALOR_DESEMBOLSO,SID_FECHA_DESEMBOLSO,
		                                                                                   SID_APLICADO,SID_ANULADO,SID_CREADO_POR,SID_FECHA_CREACION
											)
						
		Values (@SID_ID,@SOC_ID,@FRC_ID,@SID_VALOR_DESEMBOLSO,@SID_FECHA_DESEMBOLSO,
                    'N','N',@SID_CREADO_POR,@SID_FECHA_CREACION
			)	
	End
	Else
	Begin
		Update SID_SOLICITUD_INF_DESEMBOLSO Set FRC_ID=@FRC_ID,
																	                      SID_VALOR_DESEMBOLSO=@SID_VALOR_DESEMBOLSO,
																						  SID_FECHA_DESEMBOLSO=@SID_FECHA_DESEMBOLSO,
																						  SID_ACTUALIZADO_POR=@SID_CREADO_POR,
																						  SID_FECHA_ACTUALIZA=@SID_FECHA_CREACION
	 Where SID_ID = @SID_ID
	   And SOC_ID = @SOC_ID

	End
	-- Retorno los Datos de los Desembolsos
	Select  * From SID_SOLICITUD_INF_DESEMBOLSO
	 Where SID_ID = @SID_ID
	   And SOC_ID = @SOC_ID
END
