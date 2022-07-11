USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerIntegranteComite]    Script Date: 6/07/2021 4:36:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerIntegranteComite
Descripcion: Obteniene Integrantes del Comite de Credito
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 19 de 2021
*/

ALTER PROC [dbo].[ObtenerIntegranteComite]
as
	SELECT ICO_ID, ICO_NOMBRE, ICO_CARGO, ICO_TIPO, ICO_ESTADO, 
		   ICO_CREADO_POR, ICO_FECHA_CREACION
	FROM ICO_INTEGRANTE_COMITE_CREDITO
	ORDER BY ICO_ID