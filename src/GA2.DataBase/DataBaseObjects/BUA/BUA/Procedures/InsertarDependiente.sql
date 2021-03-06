CREATE OR ALTER PROCEDURE [dbo].[InsertarDependienteIntegracion] (
		@IdCliente					INT
		,@IdTipoIdentificacion		INT
		,@Identificacion			VARCHAR(20)
		,@Nombre					VARCHAR(30)
		,@Participacion				NUMERIC(18,2)
)
AS
BEGIN
	INSERT INTO DPT_DEPENDIENTE(
		CLI_ID
		,TID_ID
		,DPT_IDENTIFICACION
		,DPT_NOMBRE
		,DPT_PARTICIPACION)
	VALUES (
		@IdCliente				
		,@IdTipoIdentificacion	
		,@Identificacion
		,@Nombre
		,@Participacion)		

	SELECT * FROM DPT_DEPENDIENTE WHERE DPT_IDENTIFICACION = @Identificacion AND CLI_ID = @IdCliente
END 	
