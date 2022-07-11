USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAlertaAutomaticasPorId]    Script Date: 6/07/2021 11:32:20 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerAlertaAutomatica
Descripcion: Consulta los datos de las alertas para el envio de los correos a los usuarios
Elaboro: German Eduardo Guarnizo
Fecha: Abril 16 de 2021
*/
ALTER PROC [dbo].[ObtenerAlertaAutomaticasPorId]
@ALA_ID int=0

AS
Begin
	Select *, URL_CREDITO as URL From ALA_ALERTA_AUTOMATICAS,  [dbo].[PRM_SIMULADOR]
	 Where (@ALA_ID=0 Or ALA_ID = @ALA_ID)
	Order by ALA_ID
End