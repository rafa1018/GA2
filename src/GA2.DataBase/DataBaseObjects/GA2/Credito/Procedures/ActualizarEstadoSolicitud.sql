USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEstadoSolicitud]    Script Date: 6/07/2021 11:58:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <04/05/2021>
-- Description:	<Sp para la actualziacion de datos en la tabla [dbo].[ESS_ESTADO_SOLICITUD]>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarEstadoSolicitud]
	-- Add the parameters for the stored procedure here
	@ESS_ID int
	,@ESS_DESCRIPCION varchar(70)  
	,@ESS_SIGLA char(1)  
	,@ESS_ESTADO int  
	,@ESS_CREADO_POR uniqueidentifier 
	,@ESS_FECHA_CREACION datetime   
	,@ESS_MODIFICADO_POR uniqueidentifier 
	,@ESS_FECHA_MODIFICACION datetime 
AS
BEGIN
UPDATE [GA2].[dbo].[ESS_ESTADO_SOLICITUD]
	SET 
	ESS_DESCRIPCION=@ESS_DESCRIPCION
	,ESS_SIGLA=@ESS_SIGLA  
	,ESS_ESTADO=@ESS_ESTADO
	,ESS_CREADO_POR=@ESS_CREADO_POR
	,ESS_FECHA_CREACION=@ESS_FECHA_CREACION
	,ESS_MODIFICADO_POR=@ESS_MODIFICADO_POR
	,ESS_FECHA_MODIFICACION=@ESS_FECHA_MODIFICACION
WHERE ESS_ID=@ESS_ID
SELECT
	ESS_ID
	,ESS_DESCRIPCION
	,ESS_SIGLA  
	,ESS_ESTADO
	,ESS_CREADO_POR
	,ESS_FECHA_CREACION
	,ESS_MODIFICADO_POR
	,ESS_FECHA_MODIFICACION
FROM
	[GA2].[dbo].[ESS_ESTADO_SOLICITUD]
WHERE
	ESS_ID=ESS_ID
END
