USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarAseguradoras]    Script Date: 6/07/2021 11:18:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Sp para la actualziacion de datos en la tabla [dbo].[ASE_ASEGURADORAS]>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarAseguradoras]
	-- Add the parameters for the stored procedure here
	@ASE_ID int
	,@ASE_RAZON_SOCIAL varchar(100)
	,@ASE_SITIO_WEB varchar(100)
	,@ASE_ESTADO int
	,@ASE_CREADO_POR uniqueidentifier
	,@ASE_FECHA_CREACION datetime
	,@ASE_ACTUALIZADO_POR uniqueidentifier
	,@ASE_FECHA_ACTUALIZA datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE
	[GA2].[dbo].[ASE_ASEGURADORAS]
SET 
	ASE_RAZON_SOCIAL=@ASE_RAZON_SOCIAL
	,ASE_SITIO_WEB=@ASE_SITIO_WEB 
	,ASE_ESTADO=@ASE_ESTADO 
	,ASE_CREADO_POR=@ASE_CREADO_POR
	,ASE_FECHA_CREACION=@ASE_FECHA_CREACION
	,ASE_ACTUALIZADO_POR=@ASE_ACTUALIZADO_POR
	,ASE_FECHA_ACTUALIZA=@ASE_FECHA_ACTUALIZA
WHERE ASE_ID=@ASE_ID
SELECT
	ASE_ID
	,ASE_RAZON_SOCIAL
	,ASE_SITIO_WEB
	,ASE_ESTADO
	,ASE_CREADO_POR
	,ASE_FECHA_CREACION
	,ASE_ACTUALIZADO_POR
	,ASE_FECHA_ACTUALIZA
FROM
	[GA2].[dbo].[ASE_ASEGURADORAS]
WHERE
	ASE_ID=@ASE_ID
END
