USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerConsecutivoPorId]    Script Date: 27/04/2021 5:05:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <26/04/2021>
-- Description:	<Obtener consecutivo por id>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerConsecutivoPorId]
	-- Add the parameters for the stored procedure here
			@CNS_ID varchar(2)
           
AS
BEGIN
			SELECT	CNS_ID
		           ,CNS_DESCRIPCION
		           ,CNS_ULTIMO_NUMERO
		           ,CNS_ESTADO
		           ,CNS_CREADO_POR
		           ,CNS_FECHA_CREACION
		           ,CNS_ACTUALIZADO_POR
		           ,CNS_FECHA_ACTUALIZA
	FROM 
					CNS_CONSECUTIVO
	WHERE			CNS_ID=@CNS_ID 
	
END
