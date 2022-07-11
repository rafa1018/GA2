USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTipoActividadPorId]    Script Date: 7/07/2021 12:06:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Obtener consecutivo por id>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerTipoActividadPorId]
	-- Add the parameters for the stored procedure here
	@TAC_ID int
           
AS
BEGIN
SELECT	
	TAC_ID
	,TAC_DESCRIPCION
	,TAC_ESTADO
	,TAC_CREADO_POR
	,TAC_FECHA_CREACION
	,TAC_MODIFICADO_POR
	,TAC_FECHA_MODIFICACION
FROM 
	[GA2].[dbo].[TAC_TIPO_ACTIVIDAD]
WHERE
	TAC_ID=@TAC_ID
END
