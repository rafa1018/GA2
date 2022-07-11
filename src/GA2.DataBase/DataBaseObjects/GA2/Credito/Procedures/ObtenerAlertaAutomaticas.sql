USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAlertaAutomaticas]    Script Date: 6/07/2021 11:28:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <10/05/2021>
-- Description:	<SP para la obtener alertas automaticas >
-- =============================================
ALTER PROC [dbo].[ObtenerAlertaAutomaticas]
AS
SELECT
	ALA_ID
	,ALA_DESCRIPCION 
	,ALA_MENSAJE 
	,ALA_FECHA_CREACION
	,ALA_MODIFICADO_POR
	,ALA_FECHA_MODIFICACION
FROM
	ALA_ALERTA_AUTOMATICAS

