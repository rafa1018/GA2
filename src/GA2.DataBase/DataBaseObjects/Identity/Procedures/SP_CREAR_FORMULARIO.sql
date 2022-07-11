--------------------------------------
--- Author: Oscar Julian Rojas
--- Descripcion: Crear Formularios
--- Date: 21/04/2021
--------------------------------------

CREATE PROCEDURE CrearFormulario
   @FRM_ID uniqueidentifier, 
   @FRM_SUBMODULOID uniqueidentifier,
   @FRM_DESCRIPCION nvarchar(50),
   @FRM_VISIBLE bit,
   @FRM_CREATEBY uniqueidentifier,
   @FRM_CREATEON Datetime, 
   @FRM_STATE bit
AS 
BEGIN
INSERT INTO FRM_FORMULARIO
(FRM_ID, FRM_SUBMODULOID, FRM_DESCRIPCION, FRM_VISIBLE, FRM_CREATEBY, FRM_CREATEON, FRM_STATE)
VALUES(@FRM_ID,   
@FRM_SUBMODULOID,
@FRM_DESCRIPCION,  
@FRM_VISIBLE,
@FRM_CREATEBY,   
@FRM_CREATEON,	
@FRM_STATE)
END;
