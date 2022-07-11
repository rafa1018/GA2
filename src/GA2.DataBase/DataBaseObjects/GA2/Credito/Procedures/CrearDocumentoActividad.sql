USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearDocumentoActividad]    Script Date: 7/07/2021 12:42:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <07/05/2021>
-- Description:	<SP para la creación de Flujo Actividad>
-- =============================================
CREATE PROCEDURE [dbo].[CrearDocumentoActividad]
	
	@AFL_ID int 
	,@TDC_ID int 
	,@DCA_ORDEN int 
	,@DCA_OBLIGATORIO char(1) 
	,@DCA_CARGA char(1) 
	,@DCA_VISUALIZA char(1) 
	,@DCA_VISUALIZA_CLIENTE char(1) 
	,@DCA_ESTADO int 
	,@DCA_CREADO_POR uniqueidentifier 
	,@DCA_FECHA_CREACION datetime 
	,@DCA_MODIFICADO_POR uniqueidentifier 
	,@DCA_FECHA_MODIFICACION datetime 
AS 
BEGIN
 IF  Not EXISTS (SELECT TOP 1 * FROM [dbo].[DCA_DOCUMENTO_ACTIVIDAD] WITH (NOLOCK) WHERE AFL_ID = @AFL_ID and TDC_ID = @TDC_ID) 
BEGIN
			INSERT INTO [GA2].[dbo].[DCA_DOCUMENTO_ACTIVIDAD]
			(
				AFL_ID
				,TDC_ID
				,DCA_ORDEN
				,DCA_OBLIGATORIO
				,DCA_CARGA
				,DCA_VISUALIZA
				,DCA_VISUALIZA_CLIENTE
				,DCA_ESTADO
				,DCA_CREADO_POR
				,DCA_FECHA_CREACION
				,DCA_MODIFICADO_POR
				,DCA_FECHA_MODIFICACION
			) 
				VALUES
					(    
				 @AFL_ID
				,@TDC_ID
				,@DCA_ORDEN
				,@DCA_OBLIGATORIO
				,@DCA_CARGA
				,@DCA_VISUALIZA
				,@DCA_VISUALIZA_CLIENTE
				,@DCA_ESTADO
				,@DCA_CREADO_POR
				,@DCA_FECHA_CREACION
				,@DCA_MODIFICADO_POR
				,@DCA_FECHA_MODIFICACION
					)
					SELECT TOP (1)
					DCA_ID
					,AFL_ID
					,TDC_ID
					,DCA_ORDEN
					,DCA_OBLIGATORIO
					,DCA_CARGA
					,DCA_VISUALIZA
					,DCA_VISUALIZA_CLIENTE
					,DCA_ESTADO
					,DCA_CREADO_POR
					,DCA_FECHA_CREACION
					,DCA_MODIFICADO_POR
					,DCA_FECHA_MODIFICACION
					FROM
						[DCA_DOCUMENTO_ACTIVIDAD]
					ORDER BY DCA_ID DESC
		END
		ELSE 
		BEGIN
		 SELECT 'EL REGISTRO YA EXISTE'
		 END
END



