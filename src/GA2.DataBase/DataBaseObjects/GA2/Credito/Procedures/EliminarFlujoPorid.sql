USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarFlujoPorid]    Script Date: 7/07/2021 12:18:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Eliminar documento por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarFlujoPorid]
	-- Add the parameters for the stored procedure here
	@FLU_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [FLU_FLUJO]
SET
	FLU_ESTADO=0         
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