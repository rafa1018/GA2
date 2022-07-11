USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearFlujoTipoCredito]    Script Date: 7/07/2021 12:23:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <23/04/2021>
-- Description:	<SP para la creación de Flujo tipo Credito>
-- =============================================
CREATE PROCEDURE [dbo].[CrearFlujoTipoCredito]
	 
	@FLU_ID int  
	,@TCR_ID int  
	,@FTC_ESTADO int  
	,@FTC_CREADO_POR uniqueidentifier  
	,@FTC_FECHA_CREACION datetime  
	,@FTC_MODIFICADO_POR uniqueidentifier 
	,@FTC_FECHA_MODIFICACION datetime 
AS 
BEGIN
 IF  Not EXISTS (SELECT TOP 1 * FROM [dbo].[FTC_FLUJO_TIPO_CREDITO] WITH (NOLOCK) WHERE FLU_ID = @FLU_ID and TCR_ID = @TCR_ID) 
BEGIN
			INSERT INTO [GA2].[dbo].[FTC_FLUJO_TIPO_CREDITO]
			(
				FLU_ID   
					,TCR_ID 
					,FTC_ESTADO  
					,FTC_CREADO_POR  
					,FTC_FECHA_CREACION  
					,FTC_MODIFICADO_POR  
					,FTC_FECHA_MODIFICACION 
					) 
				VALUES
					(    
					 
					@FLU_ID   
					,@TCR_ID 
					,@FTC_ESTADO 
					,@FTC_CREADO_POR  
					,@FTC_FECHA_CREACION  
					,@FTC_MODIFICADO_POR  
					,@FTC_FECHA_MODIFICACION 
			)
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
		ELSE 
		BEGIN
		 SELECT 'EL REGISTRO YA EXISTE'
		 END
END



