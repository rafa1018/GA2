USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerFlujoPorId]    Script Date: 7/07/2021 12:20:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Obtener Tipo Documento por id>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerFlujoPorId]
	-- Add the parameters for the stored procedure here
	@FLU_ID int
           
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
	FLU_ID=@FLU_ID and
	[FLU_ESTADO]=1
ORDER BY
	[FLU_ID] DESC
	
END
