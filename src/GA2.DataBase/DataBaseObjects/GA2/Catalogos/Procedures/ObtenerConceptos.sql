-- =============================================
-- Author:		Oscar Rojas
-- Create date: 25/05/2021
-- Description:	SP para la obtener los conceptos 
-- =============================================
Create procedure ObtenerConceptos
AS
SELECT CNC_ID, CNC_DESCRIPCION, CNC_FORMULA_CALCULO, CNC_ORDEN, CAT_TIPO_CONCEPTO, CNC_INTERES
FROM GA2.dbo.CNC_CONCEPTO;
