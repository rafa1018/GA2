USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEstadoActividad]    Script Date: 6/07/2021 11:53:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <03/05/2021>
-- Description:	<Sp para la actualziacion de datos en la tabla [dbo].[ASE_ASEGURADORAS]>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarEstadoActividad]
	-- Add the parameters for the stored procedure here
	 @ESA_ID int
	,@ESA_DESCRIPCION varchar(70) 
	,@ESA_ESTADO int 
	,@ESA_CREADO_POR uniqueidentifier 
	,@ESA_FECHA_CREACION datetime 
	,@ESA_MODIFICADO_POR uniqueidentifier 
	,@ESA_FECHA_MODIFICACION datetime 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE 
	[dbo].[ESA_ESTADO_ACTIVIDAD]
SET 
	ESA_DESCRIPCION=@ESA_DESCRIPCION
	,ESA_ESTADO=@ESA_ESTADO
	,ESA_CREADO_POR=@ESA_CREADO_POR
	,ESA_FECHA_CREACION=@ESA_FECHA_CREACION
	,ESA_MODIFICADO_POR=@ESA_MODIFICADO_POR
	,ESA_FECHA_MODIFICACION=@ESA_FECHA_MODIFICACION
WHERE 
	ESA_ID=@ESA_ID
select
	 ESA_ID
	,ESA_DESCRIPCION
	,ESA_ESTADO
	,ESA_CREADO_POR
	,ESA_FECHA_CREACION
	,ESA_MODIFICADO_POR
	,ESA_FECHA_MODIFICACION
from 
	[GA2].[dbo].[ESA_ESTADO_ACTIVIDAD]
where			
	ESA_ID=@ESA_ID
END
