USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuarioActividad]    Script Date: 7/07/2021 12:37:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <07/05/2021>
-- Description:	<SP para la creación de Flujo Actividad>
-- =============================================
CREATE  PROCEDURE [dbo].[CrearUsuarioActividad]
	
	@AFL_ID int  
	,@ID_USERS uniqueidentifier  
	,@USA_ESTADO int  
	,@USA_CREADO_POR uniqueidentifier 
	,@USA_FECHA_CREACION datetime  
	,@USA_MODIFICADO_POR uniqueidentifier 
	,@USA_FECHA_MODIFICACION datetime 
AS 
BEGIN

DECLARE @VALIDAR TABLE ( 
	 AFL_ID int  
	,ID_USERS uniqueidentifier  
	,USA_ESTADO int  
	,USA_CREADO_POR uniqueidentifier 
	,USA_FECHA_CREACION datetime  
	,USA_MODIFICADO_POR uniqueidentifier 
	,USA_FECHA_MODIFICACION datetime)


	INSERT INTO @VALIDAR
	SELECT		    
	    @AFL_ID
       ,@ID_USERS
       ,@USA_ESTADO
       ,@USA_CREADO_POR
       ,@USA_FECHA_CREACION
       ,@USA_MODIFICADO_POR				
       ,@USA_FECHA_MODIFICACION


	   	INSERT INTO [GA2].[dbo].[USA_USUARIO_ACTIVIDAD]
			(
                AFL_ID
                ,ID_USERS
                ,USA_ESTADO
                ,USA_CREADO_POR
                ,USA_FECHA_CREACION
                ,USA_MODIFICADO_POR
                ,USA_FECHA_MODIFICACION
			) 
		SELECT   V.AFL_ID
                ,V.ID_USERS
                ,V.USA_ESTADO
                ,V.USA_CREADO_POR
                ,V.USA_FECHA_CREACION
                ,V.USA_MODIFICADO_POR
                ,V.USA_FECHA_MODIFICACION
				FROM @VALIDAR V
				WHERE NOT EXISTS (SELECT TOP 1 1
									FROM [GA2].[dbo].[USA_USUARIO_ACTIVIDAD] UA WITH (NOLOCK)
									WHERE 1=1
									AND (UA.AFL_ID = V.AFL_ID AND UA.ID_USERS = V.ID_USERS)
									AND  UA.ID_USERS = V.ID_USERS AND UA.AFL_ID = 1)

	
		SELECT   UA.AFL_ID
                ,UA.ID_USERS
                ,UA.USA_ESTADO
                ,UA.USA_CREADO_POR
                ,UA.USA_FECHA_CREACION
                ,UA.USA_MODIFICADO_POR
                ,UA.USA_FECHA_MODIFICACION
		FROM [GA2].[dbo].[USA_USUARIO_ACTIVIDAD] UA WITH (NOLOCK)
		JOIN @VALIDAR V ON UA.AFL_ID = V.AFL_ID
						AND UA.ID_USERS = V.ID_USERS
						AND UA.USA_CREADO_POR = V.USA_CREADO_POR
						AND UA.USA_ESTADO = V.USA_ESTADO
						AND UA.USA_FECHA_CREACION = V.USA_FECHA_CREACION
						AND UA.USA_FECHA_MODIFICACION = V.USA_FECHA_MODIFICACION
						AND UA.USA_MODIFICADO_POR = V.USA_MODIFICADO_POR

		IF (@@ROWCOUNT < 1)
		BEGIN
		SELECT 'NO SE HA PODIO INSERTAR LA ACTIVIDAD DE USUARIO'
		END
	

 
END



