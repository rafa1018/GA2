USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerFlujo]    Script Date: 7/07/2021 12:18:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Obtener Tipo de documento>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerFlujo]
AS
BEGIN
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
	[FLU_ESTADO]=1
ORDER BY
	[FLU_ID] DESC
END
