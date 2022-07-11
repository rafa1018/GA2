﻿
IF OBJECT_ID('ConsultarTerceroBeneficiario', 'P') > 0
BEGIN
	DROP PROCEDURE ConsultarTerceroBeneficiario
END
GO
CREATE PROCEDURE ConsultarTerceroBeneficiario
	@SOL_ID_FK				UNIQUEIDENTIFIER,
	@TER_TIPO_TERCERO_FK	INT
AS
BEGIN
	SELECT 
		TER_TERCERO.TER_ID, TER_TERCERO.TID_ID_FK, TID_TIPO_IDENTIFICACION.TID_DESCRIPCION, TER_TERCERO.TER_NUMERO_DOCUMENTO, 
		TER_TERCERO.TER_NOMBRE_RAZON_SOCIAL, ENT_ENTIDAD_BANCARIA.ENT_ID, ENT_ENTIDAD_BANCARIA.ENT_NOMBRE_RAZON_SOCIAL,
		CVL_CATALOGO_VALOR.CVL_ID, CVL_CATALOGO_VALOR.CVL_DESCRIPCION, TER_TERCERO.TER_NUMERO_CUENTA
	FROM TER_TERCERO 
		INNER JOIN TID_TIPO_IDENTIFICACION ON TER_TERCERO.TID_ID_FK = TID_TIPO_IDENTIFICACION.TID_ID
		INNER JOIN ENT_ENTIDAD_BANCARIA ON TER_TERCERO.ENT_ID_FK = ENT_ENTIDAD_BANCARIA.ENT_ID
		INNER JOIN CVL_CATALOGO_VALOR ON TER_TERCERO.TER_TIPO_CUENTA_FK = CVL_CATALOGO_VALOR.CVL_ID
	WHERE SOL_ID_FK = @SOL_ID_FK AND TER_TIPO_TERCERO_FK = @TER_TIPO_TERCERO_FK
END