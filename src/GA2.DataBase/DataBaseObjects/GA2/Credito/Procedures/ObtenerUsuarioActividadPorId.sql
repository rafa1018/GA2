USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioActividadPorId]    Script Date: 7/07/2021 12:40:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <10/05/2021>
-- Description:	<SP para la obtener Actividad de usuario por id>
-- =============================================
CREATE PROC [dbo].[ObtenerUsuarioActividadPorId]
	@USA_ID int
as
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
	USA_ESTADO = 1 and
	USA_ID=@USA_ID
ORDER by 
	USA_ID