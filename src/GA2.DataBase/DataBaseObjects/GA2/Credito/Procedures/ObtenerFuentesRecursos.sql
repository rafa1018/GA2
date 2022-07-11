USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerFuentesRecursos]    Script Date: 6/07/2021 4:43:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================
-- Author:		German Guarnizo
-- Create date: 11/06/2021
-- Description:	SP para obtener  las Fuentes de Recursos
-- ==================================================
ALTER procedure [dbo].[ObtenerFuentesRecursos]
AS
SELECT  FRC_ID, FRC_DESCRIPCION,FRC_CAJA,FRC_ESTADO,FRC_CREADO_POR,FRC_FECHA_CREACION
FROM GA2.dbo.FRC_FUENTES_RECURSOS
 Where FRC_ESTADO = 1
 Order by FRC_DESCRIPCION