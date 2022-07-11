USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarFlujo]    Script Date: 7/07/2021 12:13:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Sp para la actualizacion de datos en la tabla CrearFlujo>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarFlujo]
	
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
UPDATE
	[FLU_FLUJO]
SET 
		
      FLU_DESCRIPCION=@FLU_DESCRIPCION
      ,FLU_ORDEN=@FLU_ORDEN
      ,FLU_ESTADO=@FLU_ESTADO
      ,FLU_CREADO_POR=@FLU_CREADO_POR
      ,FLU_FECHA_CREACION=@FLU_FECHA_CREACION
      ,FLU_MODIFICADO_POR=@FLU_MODIFICADO_POR
      ,FLU_FECHA_MODIFICACION=@FLU_FECHA_MODIFICACION
WHERE 
	FLU_ID=@FLU_ID
SELECT	
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
WHERE
	FLU_ID=@FLU_ID
END
