USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarConsecutivoPorId]    Script Date: 27/04/2021 5:04:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <27/04/2021>
-- Description:	<Eliminar consecutivo por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarConsecutivoPorId]
	-- Add the parameters for the stored procedure here
			@CNS_ID varchar(2)   
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [GA2].[dbo].[CNS_CONSECUTIVO]
	SET
           CNS_ESTADO=0
           
           
	WHERE CNS_ID=@CNS_ID
	select			CNS_ID
		           ,CNS_DESCRIPCION
		           ,CNS_ULTIMO_NUMERO
		           ,CNS_ESTADO
		           ,CNS_CREADO_POR
		           ,CNS_FECHA_CREACION
		           ,CNS_ACTUALIZADO_POR
		           ,CNS_FECHA_ACTUALIZA
	FROM
					CNS_CONSECUTIVO
	WHERE			
					CNS_ID=@CNS_ID 
END