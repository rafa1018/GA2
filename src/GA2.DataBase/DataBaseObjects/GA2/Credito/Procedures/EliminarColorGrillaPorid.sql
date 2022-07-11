USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarColorGrillaPorid]    Script Date: 6/07/2021 11:50:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <30/04/2021>
-- Description:	<Eliminar ColorGrilla por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarColorGrillaPorid]
	-- Add the parameters for the stored procedure here
				@CLG_ID int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [GA2].[dbo].[CLG_COLOR_GRILLA]
	SET
           CLG_ESTADO=0
           
           
	WHERE CLG_ID=@CLG_ID
	select			
			 CLG_DESCRIPCION
			,CLG_ESTILO_COLOR
			,CLG_ESTADO 
			,CLG_CREADO_POR
			,CLG_FECHA_CREACION
			,CLG_ACTUALIZADO_POR
			,CLG_FECHA_ACTUALIZA
	FROM
					[GA2].[dbo].[CLG_COLOR_GRILLA]
	WHERE			
					CLG_ID=@CLG_ID 
END