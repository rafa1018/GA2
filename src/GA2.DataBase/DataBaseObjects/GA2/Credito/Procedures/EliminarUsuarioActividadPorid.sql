USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuarioActividadPorid]    Script Date: 7/07/2021 12:38:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <10/04/2021>
-- Description:	<Eliminar Usuario Actividad por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarUsuarioActividadPorid]
	-- Add the parameters for the stored procedure here
	@USA_ID int
AS
BEGIN
UPDATE
	[USA_USUARIO_ACTIVIDAD]
SET
    USA_ESTADO=0       
WHERE
	USA_ID=@USA_ID
SELECT
		USA_ID
	   ,AFL_ID
       ,ID_USERS
       ,USA_ESTADO
       ,USA_CREADO_POR
       ,USA_FECHA_CREACION
       ,USA_MODIFICADO_POR				
       ,USA_FECHA_MODIFICACION 
FROM
	[USA_USUARIO_ACTIVIDAD]
WHERE			
	USA_ID=@USA_ID
END