USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearTipoDocumento]    Script Date: 7/07/2021 12:08:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <07/05/2021>
-- Description:	<SP para la creación de Tipo Documento>
-- =============================================
CREATE PROCEDURE [dbo].[CrearTipoDocumento]

	
	@TDC_DESCRIPCION varchar(70)  
	,@TDC_ESTADO int  
	,@TDC_CREADO_POR uniqueidentifier  
	,@TDC_FECHA_CREACION datetime  
	,@TDC_MODIFICADO_POR uniqueidentifier 
	,@TDC_FECHA_MODIFICACION datetime 
AS 
BEGIN
INSERT INTO TDC_TIPO_DOCUMENTO
(					 
	TDC_DESCRIPCION
      ,TDC_ESTADO
      ,TDC_CREADO_POR
      ,TDC_FECHA_CREACION
      ,TDC_MODIFICADO_POR
      ,TDC_FECHA_MODIFICACION
) 
VALUES
(    					 
	@TDC_DESCRIPCION
      ,@TDC_ESTADO
      ,@TDC_CREADO_POR
      ,@TDC_FECHA_CREACION
      ,@TDC_MODIFICADO_POR
      ,@TDC_FECHA_MODIFICACION
)
SELECT 	TOP(1)
	TDC_ID
	,TDC_DESCRIPCION
    ,TDC_ESTADO
    ,TDC_CREADO_POR
    ,TDC_FECHA_CREACION
    ,TDC_MODIFICADO_POR
    ,TDC_FECHA_MODIFICACION
FROM
	TDC_TIPO_DOCUMENTO
ORDER BY TDC_ID DESC
END


