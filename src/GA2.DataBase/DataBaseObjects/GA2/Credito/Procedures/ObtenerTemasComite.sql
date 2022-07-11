USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTemasComite]    Script Date: 6/07/2021 4:39:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerTemasComite
Descripcion: Obteniene Temas del Orden del Dia del Comite de Credito
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 19 de 2021
*/

ALTER PROC [dbo].[ObtenerTemasComite]
as
	SELECT TCO_ID, TCO_DESCRIPCION, TCO_ESTADO, 
		   TCO_CREADO_POR, TCO_FECHA_CREACION
	FROM TCO_TEMAS_COMITE_CREDITO
	ORDER BY TCO_ID