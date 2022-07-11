USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarTipoActividad]    Script Date: 7/07/2021 12:03:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <04/05/2021>
-- Description:	<Sp para la actualziacion de datos en la tabla [dbo].[TAC_TIPO_ACTIVIDAD]>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarTipoActividad]
	-- Add the parameters for the stored procedure here
	 @TAC_ID int
	,@TAC_DESCRIPCION varchar(70)  
	,@TAC_ESTADO int  
	,@TAC_CREADO_POR uniqueidentifier  
	,@TAC_FECHA_CREACION datetime  
	,@TAC_MODIFICADO_POR uniqueidentifier 
	,@TAC_FECHA_MODIFICACION datetime 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE
	[GA2].[dbo].[TAC_TIPO_ACTIVIDAD]
SET 
	TAC_DESCRIPCION=@TAC_DESCRIPCION    
	,TAC_ESTADO =@TAC_ESTADO 
	,TAC_CREADO_POR=@TAC_CREADO_POR
	,TAC_FECHA_CREACION=@TAC_FECHA_CREACION
	,TAC_MODIFICADO_POR=@TAC_MODIFICADO_POR
	,TAC_FECHA_MODIFICACION=@TAC_FECHA_MODIFICACION
WHERE 
	TAC_ID=@TAC_ID
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
