USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCausalDesistimiento]    Script Date: 6/07/2021 4:47:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================
-- Author:		German Guarnizo
-- Create date: 11/06/2021
-- Description:	SP para obtener  las Causales de Desistimiento
-- ==================================================
ALTER procedure [dbo].[ObtenerCausalDesistimiento]
AS
SELECT  CDD_ID, CDD_DESCRIPCION,CDD_ESTADO,CDD_CREADO_POR,CDD_FECHA_CREACION
FROM GA2.dbo.CDD_CAUSAL_DESISTIMIENTO_DES
 Where CDD_ESTADO = 1
 Order by CDD_DESCRIPCION
