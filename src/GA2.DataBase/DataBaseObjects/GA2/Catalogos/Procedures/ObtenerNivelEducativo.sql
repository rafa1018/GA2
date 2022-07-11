﻿IF OBJECT_ID('ObtenerNivelEducativo', 'P') > 0
BEGIN
	DROP PROCEDURE ObtenerNivelEducativo
END
GO
CREATE PROCEDURE ObtenerNivelEducativo
	@PGN_ID_FK					UNIQUEIDENTIFIER
AS
BEGIN
	SELECT PRN_PROGRAMA_NIVEL.PRN_ID, UPPER(NVE_NIVEL_EDUCATIVO.NVE_DESCRIPCION) AS NVE_DESCRIPCION
	FROM NVE_NIVEL_EDUCATIVO 
		INNER JOIN PRN_PROGRAMA_NIVEL ON NVE_NIVEL_EDUCATIVO.NVE_ID = PRN_PROGRAMA_NIVEL.NVE_ID_FK
	WHERE PRN_PROGRAMA_NIVEL.PGN_ID_FK = @PGN_ID_FK
END