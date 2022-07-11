USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearEstadoSolicitud]    Script Date: 6/07/2021 11:59:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <04/05/2021>
-- Description:	<SP para la creación de ESS_ESTADO_SOLICITUD>
-- =============================================
CREATE PROCEDURE [dbo].[CrearEstadoSolicitud]

	@ESS_DESCRIPCION varchar(70)  
	,@ESS_SIGLA char(1)  
	,@ESS_ESTADO int  
	,@ESS_CREADO_POR uniqueidentifier 
	,@ESS_FECHA_CREACION datetime   
	,@ESS_MODIFICADO_POR uniqueidentifier 
	,@ESS_FECHA_MODIFICACION datetime 

AS 
BEGIN
INSERT INTO [GA2].[dbo].[ESS_ESTADO_SOLICITUD]
(
	 ESS_DESCRIPCION
	,ESS_SIGLA  
	,ESS_ESTADO
	,ESS_CREADO_POR
	,ESS_FECHA_CREACION
	,ESS_MODIFICADO_POR
	,ESS_FECHA_MODIFICACION
) 
VALUES
(    
	@ESS_DESCRIPCION
	,@ESS_SIGLA 
	,@ESS_ESTADO 
	,@ESS_CREADO_POR 
	,@ESS_FECHA_CREACION 
	,@ESS_MODIFICADO_POR 
	,@ESS_FECHA_MODIFICACION 
)
select TOP(1)
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
	ORDER BY ESS_ID DESC
END


