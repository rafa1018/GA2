
USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarConsecutivo]    Script Date: 27/04/2021 5:08:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <26/04/2021>
-- Description:	<Sp para la actualziacion de datos en la tablas CNS_CONSECUTIVO>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarConsecutivo]
	-- Add the parameters for the stored procedure here
			@CNS_ID varchar(2)
           ,@CNS_DESCRIPCION varchar(255)
           ,@CNS_ULTIMO_NUMERO bigint
           ,@CNS_ESTADO int
           ,@CNS_CREADO_POR uniqueidentifier
           ,@CNS_FECHA_CREACION datetime
           ,@CNS_ACTUALIZADO_POR uniqueidentifier
           ,@CNS_FECHA_ACTUALIZA datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [GA2].[dbo].[CNS_CONSECUTIVO]
	SET
			CNS_ID=@CNS_ID
           ,CNS_DESCRIPCION=@CNS_DESCRIPCION
           ,CNS_ULTIMO_NUMERO=@CNS_ULTIMO_NUMERO
           ,CNS_ESTADO=@CNS_ESTADO
           ,CNS_CREADO_POR=@CNS_CREADO_POR
           ,CNS_FECHA_CREACION=@CNS_FECHA_CREACION
           ,CNS_ACTUALIZADO_POR=@CNS_ACTUALIZADO_POR
           ,CNS_FECHA_ACTUALIZA=@CNS_FECHA_ACTUALIZA
	WHERE CNS_ID=@CNS_ID
	select			CNS_ID
		           ,CNS_DESCRIPCION
		           ,CNS_ULTIMO_NUMERO
		           ,CNS_ESTADO
		           ,CNS_CREADO_POR
		           ,CNS_FECHA_CREACION
		           ,CNS_ACTUALIZADO_POR
		           ,CNS_FECHA_ACTUALIZA
	from 
					CNS_CONSECUTIVO
	where			CNS_ID=@CNS_ID 
END
