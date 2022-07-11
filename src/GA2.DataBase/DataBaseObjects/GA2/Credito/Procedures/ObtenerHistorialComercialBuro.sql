USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerHistorialComercialBuro]    Script Date: 6/07/2021 4:44:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerHistorialComercialBuro
Descripcion: Consulta los datos del Historial de Credito del Buro del Cliente
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 25 de 2021
*/
ALTER PROC [dbo].[ObtenerHistorialComercialBuro]
@CLI_IDENTIFICACION varchar(15)

AS
Begin
	Select Top 1 * From CBC_CONSULTA_BURO_CLIENTE 
	Where CLI_IDENTIFICACION = @CLI_IDENTIFICACION
	  And CBC_HISTORIAL_CREDITO IS NOT NULL
    Order by CBC_FECHA_CONSULTA DESC
End