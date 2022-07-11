USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearEstadoActividad]    Script Date: 6/07/2021 11:54:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <30/04/2021>
-- Description:	<SP para la creación de ESA_ESTADO_ACTIVIDAD>
-- =============================================
CREATE PROCEDURE [dbo].[CrearEstadoActividad]
	 @ESA_DESCRIPCION varchar(70) 
	,@ESA_ESTADO int 
	,@ESA_CREADO_POR uniqueidentifier 
	,@ESA_FECHA_CREACION datetime 
	,@ESA_MODIFICADO_POR uniqueidentifier 
	,@ESA_FECHA_MODIFICACION datetime 
AS 
BEGIN
INSERT INTO [GA2].[dbo].[ESA_ESTADO_ACTIVIDAD]
	(
	 ESA_DESCRIPCION
	,ESA_ESTADO
	,ESA_CREADO_POR
	,ESA_FECHA_CREACION
	,ESA_MODIFICADO_POR
	,ESA_FECHA_MODIFICACION
	) 
VALUES 
	(    			 
	 @ESA_DESCRIPCION
	,@ESA_ESTADO 
	,@ESA_CREADO_POR 
	,@ESA_FECHA_CREACION  
	,@ESA_MODIFICADO_POR  
	,@ESA_FECHA_MODIFICACION 
	)
select TOP(1)
	 ESA_DESCRIPCION
	,ESA_ESTADO
	,ESA_CREADO_POR
	,ESA_FECHA_CREACION
	,ESA_MODIFICADO_POR
	,ESA_FECHA_MODIFICACION			
from 
	[GA2].[dbo].[ESA_ESTADO_ACTIVIDAD]
	ORDER BY ESA_ID DESC
END


