USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearFlujo]    Script Date: 7/07/2021 12:16:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <07/05/2021>
-- Description:	<SP para la creación de Crear Flujo>
-- =============================================
CREATE PROCEDURE [dbo].[CrearFlujo]

	
	@FLU_ID int   
	,@FLU_DESCRIPCION varchar(70)  
	,@FLU_ORDEN int  
	,@FLU_ESTADO int  
	,@FLU_CREADO_POR uniqueidentifier  
	,@FLU_FECHA_CREACION datetime  
	,@FLU_MODIFICADO_POR uniqueidentifier 
	,@FLU_FECHA_MODIFICACION datetime 
AS 
BEGIN
INSERT INTO [FLU_FLUJO]
(					 
		[FLU_DESCRIPCION]
      ,[FLU_ORDEN]
      ,[FLU_ESTADO]
      ,[FLU_CREADO_POR]
      ,[FLU_FECHA_CREACION]
      ,[FLU_MODIFICADO_POR]
      ,[FLU_FECHA_MODIFICACION]
) 
VALUES
(    					 
	@FLU_DESCRIPCION 
	,@FLU_ORDEN  
	,@FLU_ESTADO  
	,@FLU_CREADO_POR
	,@FLU_FECHA_CREACION
	,@FLU_MODIFICADO_POR 
	,@FLU_FECHA_MODIFICACION 
)
SELECT 	TOP(1)
	[FLU_ID]
      ,[FLU_DESCRIPCION]
      ,[FLU_ORDEN]
      ,[FLU_ESTADO]
      ,[FLU_CREADO_POR]
      ,[FLU_FECHA_CREACION]
      ,[FLU_MODIFICADO_POR]
      ,[FLU_FECHA_MODIFICACION]
FROM
	[FLU_FLUJO]
ORDER BY FLU_ID DESC
END


