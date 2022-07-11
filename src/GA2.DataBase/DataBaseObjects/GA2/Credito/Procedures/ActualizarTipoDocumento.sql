USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarTipoDocumento]    Script Date: 7/07/2021 12:07:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Sp para la actualziacion de datos en la tabla [dbo].[TAC_TIPO_ACTIVIDAD]>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarTipoDocumento]
	-- Add the parameters for the stored procedure here
	@TDC_ID int
	,@TDC_DESCRIPCION varchar(70)  
	,@TDC_ESTADO int  
	,@TDC_CREADO_POR uniqueidentifier  
	,@TDC_FECHA_CREACION datetime  
	,@TDC_MODIFICADO_POR uniqueidentifier 
	,@TDC_FECHA_MODIFICACION datetime 
AS
BEGIN
UPDATE
	TDC_TIPO_DOCUMENTO
SET 
	TDC_DESCRIPCION=@TDC_DESCRIPCION 
	,TDC_ESTADO=@TDC_ESTADO   
	,TDC_CREADO_POR=@TDC_CREADO_POR   
	,TDC_FECHA_CREACION=@TDC_FECHA_CREACION   
	,TDC_MODIFICADO_POR=@TDC_MODIFICADO_POR  
	,TDC_FECHA_MODIFICACION=@TDC_FECHA_MODIFICACION  
WHERE 
	TDC_ID=@TDC_ID
SELECT	
	TDC_ID
	,TDC_DESCRIPCION
    ,TDC_ESTADO
    ,TDC_CREADO_POR
    ,TDC_FECHA_CREACION
    ,TDC_MODIFICADO_POR
    ,TDC_FECHA_MODIFICACION
FROM
	TDC_TIPO_DOCUMENTO
WHERE
	TDC_ID=@TDC_ID
END
