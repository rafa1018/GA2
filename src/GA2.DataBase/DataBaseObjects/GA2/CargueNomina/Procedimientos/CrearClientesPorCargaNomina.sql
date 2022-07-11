-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 24/05/2021
-- Description:	Crear los afiliados del archivo de carga
-- =============================================
CREATE PROCEDURE [dbo].[CrearClientesPorCargaNomina]
	-- Add the parameters for the stored procedure here
	@Json nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

    INSERT INTO CLI_CLIENTE (
    TID_ID, CLI_IDENTIFICACION,CLI_CODIGO_MILITAR, CLI_PRIMER_NOMBRE, CLI_SEGUNDO_NOMBRE, 
    CLI_PRIMER_APELLIDO, CLI_SEGUNDO_APELLIDO, CLI_UNIDAD,GRD_ID, FRZ_ID)
    
	SELECT CAST(TIPO_IDENTIFICACION AS INT),IDENTIFICACION,CAST(CODIGO_MILITAR as nvarchar(30)) , 
	PRIMER_NOMBRE, SEGUNDO_NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO,CAST(UNIDAD_OPERATIVA as nvarchar(15)),
	GRADO, DIGITO_FUERZA  
	FROM OPENJSON (@Json)
	WITH (
    DIGITO_FUERZA INT,
    TIPO_IDENTIFICACION INT,
    IDENTIFICACION VARCHAR(MAX),
    CODIGO_MILITAR INT,
    PRIMER_NOMBRE VARCHAR(MAX),
    SEGUNDO_NOMBRE VARCHAR(MAX),
    PRIMER_APELLIDO VARCHAR(MAX),
    SEGUNDO_APELLIDO VARCHAR(MAX),
    GRADO INT,
    UNIDAD_OPERATIVA INT)

END;
