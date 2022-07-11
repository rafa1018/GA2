USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearAlertaAutomaticas]    Script Date: 6/07/2021 11:26:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <29/04/2021>
-- Description:	<SP para la creación de Alertas Automaticas>
-- =============================================
CREATE PROCEDURE [dbo].[CrearAlertaAutomaticas]
	@ALA_ID int 
	,@ALA_DESCRIPCION varchar(100) 
	,@ALA_MENSAJE varchar(1000) 
	,@ALA_FECHA_CREACION datetime 
	,@ALA_MODIFICADO_POR uniqueidentifier 
	,@ALA_FECHA_MODIFICACION datetime 
AS 
BEGIN
 IF NOT EXISTS (SELECT TOP 1 * FROM [GA2].[dbo].[ALA_ALERTA_AUTOMATICAS] WITH (NOLOCK) WHERE ALA_ID = @ALA_ID)
BEGIN
INSERT INTO [GA2].[dbo].[ALA_ALERTA_AUTOMATICAS]
	(
	ALA_ID
	,ALA_DESCRIPCION 
	,ALA_MENSAJE 
	,ALA_FECHA_CREACION
	,ALA_MODIFICADO_POR
	,ALA_FECHA_MODIFICACION
	) 
VALUES 
	(   
	@ALA_ID 
	,@ALA_DESCRIPCION
	,@ALA_MENSAJE
	,@ALA_FECHA_CREACION
	,@ALA_MODIFICADO_POR
	,@ALA_FECHA_MODIFICACION
	 )
END
SELECT 	TOP(1)
	ALA_ID
	,ALA_DESCRIPCION 
	,ALA_MENSAJE 
	,ALA_FECHA_CREACION
	,ALA_MODIFICADO_POR
	,ALA_FECHA_MODIFICACION
FROM
	[ALA_ALERTA_AUTOMATICAS]
ORDER BY ALA_ID DESC
END


