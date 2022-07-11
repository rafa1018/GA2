﻿/*
Nombre: ActualizarProducto
Descripcion: Actualiza el producto por el id
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].[ActualizarProducto]
--Add the parameters for the stored procedure here
	@PRD_NUMERO_CREDITO int,
@TCR_ID int,
@PRD_FECHA_ALTA date,
@PRD_ESTADO varchar (50),
	@PRD_FECHA_ESTADO date,
	@PRD_FECHA_PAGO date,
	@PRD_DIAS_MORA int,
	@PRD_VALOR int,
	@TIV_VIVIENDA_ID int,
	@ESV_ESTADO_VIVIENDA int,
	@PRD_CREDITO int,
	@PRD_DEUDA int,
	@PRD_MORA int,
	@PRD_CUOTA_ANO int,
	@PRD_CUOTA_MES int,
	@PRD_SEGURO_VIDA decimal (4, 2), 
	@PRD_TASA_EFECTIVA_ANUAL decimal(4, 2), 
	@PRD_TASA_NOMINAL_MENSUAL decimal(4, 2), 
	@PRD_TASA_FRECH_APLICA bit,
	@PRD_TASA_FRECH decimal (4, 2), 
	@PRD_ALIVIO_COUTA_APLICA bit,
	@PRD_ALIVIO_CUOTA int  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



UPDATE PRD_PRODUCTO
	SET    TCR_ID=@TCR_ID
           , PRD_FECHA_ALTA = @PRD_FECHA_ALTA
	   , PRD_ESTADO = @PRD_ESTADO
	   , PRD_FECHA_ESTADO = @PRD_FECHA_ESTADO
	   , PRD_FECHA_PAGO = @PRD_FECHA_PAGO
	   , PRD_DIAS_MORA = @PRD_DIAS_MORA
	   , PRD_VALOR = @PRD_VALOR
	   , TIV_VIVIENDA_ID = @TIV_VIVIENDA_ID
	   , ESV_ESTADO_VIVIENDA = @ESV_ESTADO_VIVIENDA
	   , PRD_CREDITO = @PRD_CREDITO
	   , PRD_DEUDA = @PRD_DEUDA
	   , PRD_MORA = @PRD_MORA
	   , PRD_CUOTA_ANO = @PRD_CUOTA_ANO
	   , PRD_CUOTA_MES = @PRD_CUOTA_MES
	   , PRD_SEGURO_VIDA = @PRD_SEGURO_VIDA
	   , PRD_TASA_EFECTIVA_ANUAL = @PRD_TASA_EFECTIVA_ANUAL
	   , PRD_TASA_NOMINAL_MENSUAL = @PRD_TASA_NOMINAL_MENSUAL
	   , PRD_TASA_FRECH_APLICA = @PRD_TASA_FRECH_APLICA
	   , PRD_TASA_FRECH = @PRD_TASA_FRECH
	   , PRD_ALIVIO_COUTA_APLICA = @PRD_ALIVIO_COUTA_APLICA
	   , PRD_ALIVIO_CUOTA = @PRD_ALIVIO_CUOTA
	WHERE PRD_NUMERO_CREDITO=@PRD_NUMERO_CREDITO;

SELECT* FROM PRD_PRODUCTO;
END