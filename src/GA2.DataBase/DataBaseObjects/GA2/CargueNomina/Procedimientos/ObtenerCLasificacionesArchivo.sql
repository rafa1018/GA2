﻿CREATE PROC [dbo].ObtenerClasificacionesArchivo
as
	SELECT CLA_ID, CLA_CODIGO, CLA_DESCRIPCION, CLA_FECHA_CREACION, CLA_CREADO_POR, CLA_FECHA_MODIFICACION, CLA_MODIFICADO_POR, CLA_ESTADO
FROM CLA_CLASIFICACION_ARCHIVO
