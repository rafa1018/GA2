
USE [GA2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
--Create date: <23/04/2021>
-- Description:	<SP para la creación de consecutivos>
-- =============================================
CREATE PROCEDURE [dbo].[CrearConsecutivo]


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
 IF NOT EXISTS (SELECT TOP 1 * FROM [GA2].[dbo].[CNS_CONSECUTIVO] WITH (NOLOCK) WHERE CNS_ID = @CNS_ID)
	BEGIN

		INSERT INTO [GA2].[dbo].[CNS_CONSECUTIVO]
		(
					CNS_ID
		           ,CNS_DESCRIPCION
		           ,CNS_ULTIMO_NUMERO
		           ,CNS_ESTADO
		           ,CNS_CREADO_POR
		           ,CNS_FECHA_CREACION
		           ,CNS_ACTUALIZADO_POR
		           ,CNS_FECHA_ACTUALIZA
		) 
		VALUES (    @CNS_ID 
		           ,@CNS_DESCRIPCION 
		           ,@CNS_ULTIMO_NUMERO 
		           ,@CNS_ESTADO 
		           ,@CNS_CREADO_POR 
		           ,@CNS_FECHA_CREACION 
		           ,@CNS_ACTUALIZADO_POR 
		           ,@CNS_FECHA_ACTUALIZA)
		
	END
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



