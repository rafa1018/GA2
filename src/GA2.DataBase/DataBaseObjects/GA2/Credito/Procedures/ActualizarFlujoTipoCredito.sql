USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarFlujoTipoCredito]    Script Date: 7/07/2021 12:22:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Sp para la actualizacion de datos en la tabla Flujo tipo Credito>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarFlujoTipoCredito]
	
	 @FLU_ID int  
	,@TCR_ID int  
	,@FTC_ESTADO int  
	,@FTC_CREADO_POR uniqueidentifier  
	,@FTC_FECHA_CREACION datetime  
	,@FTC_MODIFICADO_POR uniqueidentifier 
	,@FTC_FECHA_MODIFICACION datetime 
AS
BEGIN
UPDATE
	[FTC_FLUJO_TIPO_CREDITO]
SET 	
	TCR_ID =@TCR_ID 
	,FTC_ESTADO =@FTC_ESTADO 
	,FTC_CREADO_POR =@FTC_CREADO_POR 
	,FTC_FECHA_CREACION =@FTC_FECHA_CREACION 
	,FTC_MODIFICADO_POR =@FTC_MODIFICADO_POR 
	,FTC_FECHA_MODIFICACION=@FTC_FECHA_MODIFICACION
		
WHERE 
	FLU_ID=@FLU_ID
SELECT 
	[FTC_ID]
	  ,[FLU_ID]
	  ,[TCR_ID]
	  ,[FTC_ESTADO]
	  ,[FTC_CREADO_POR]
	  ,[FTC_FECHA_CREACION]
	  ,[FTC_MODIFICADO_POR]
	  ,[FTC_FECHA_MODIFICACION]
	FROM
		[FTC_FLUJO_TIPO_CREDITO]
	WHERE FLU_ID=@FLU_ID
END
