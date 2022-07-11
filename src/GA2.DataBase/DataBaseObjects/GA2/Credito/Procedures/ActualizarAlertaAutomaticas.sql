USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarAlertaAutomaticas]    Script Date: 6/07/2021 11:25:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Sp para la actualziacion de datos en la tablas ALA_ALERTA_AUTOMATICAS>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarAlertaAutomaticas]
	-- Add the parameters for the stored procedure here
	@ALA_ID int 
	,@ALA_DESCRIPCION varchar(100) 
	,@ALA_MENSAJE varchar(1000) 
	,@ALA_FECHA_CREACION datetime 
	,@ALA_MODIFICADO_POR uniqueidentifier 
	,@ALA_FECHA_MODIFICACION datetime 
AS
BEGIN
UPDATE [GA2].[dbo].[ALA_ALERTA_AUTOMATICAS]
SET		
	ALA_ID=@ALA_ID 
	,ALA_DESCRIPCION=@ALA_DESCRIPCION
	,ALA_MENSAJE=@ALA_MENSAJE
	,ALA_FECHA_CREACION=@ALA_FECHA_CREACION
	,ALA_MODIFICADO_POR=@ALA_MODIFICADO_POR
	,ALA_FECHA_MODIFICACION=@ALA_FECHA_MODIFICACION
WHERE
	ALA_ID=@ALA_ID
SELECT
	ALA_ID
	,ALA_DESCRIPCION 
	,ALA_MENSAJE 
	,ALA_FECHA_CREACION
	,ALA_MODIFICADO_POR
	,ALA_FECHA_MODIFICACION
FROM
	[GA2].[dbo].[ALA_ALERTA_AUTOMATICAS]
WHERE
	ALA_ID=@ALA_ID 
END
